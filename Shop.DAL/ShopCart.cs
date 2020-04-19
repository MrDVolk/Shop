using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Models;

namespace Shop.DAL
{
    public class ShopCart
    {
        private readonly AppDBContent _appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            _appDBContent.ShopCartItem.Add(new ShopCartItem { 
            ShopCartId = ShopCartId,
            Car = car,
            Price = car.Price
            });

            _appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            var shopCartItems = _appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
            if (shopCartItems.Count() == 2 && !shopCartItems.Any(c => c.Price == 0)) //цена не меняется, а изменение корзины не сохраняются так
            {
                ShopCartItem freeCar = new ShopCartItem()
                {
                    Car = (Car)_appDBContent.Car.First(c => c.Id == 6).Clone(),
                    Price = 0,
                    ShopCartId = _appDBContent.ShopCartItem.First(c => c.ShopCartId == ShopCartId).ShopCartId
                };
                shopCartItems.Add(freeCar);
            }
            return shopCartItems;
        }
    }
}
