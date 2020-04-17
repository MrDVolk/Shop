using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Shop.Data.Interfaces;
//using Shop.Data.Models;
using Shop.Domain;
using Shop.DAL.SCart;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        public IActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();

            if (!_shopCart.ListShopItems.Any())
            {
                ModelState.AddModelError("","You should add some items to the cart first!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Purchase order is complete";
            return View();
        }
    }
}