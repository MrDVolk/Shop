//using Shop.Data.Interfaces;
//using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain;
using Shop.DAL.SCart;

namespace Shop.DAL
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly SCart.ShopCart _shopCart;

        public OrdersRepository(AppDBContent appDBContent, SCart.ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();

            var items = _shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                _appDBContent.OrderDetail.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
        }
    }
}
