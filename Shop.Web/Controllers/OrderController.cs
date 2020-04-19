using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.DAL;
using Shop.Domain.Interfaces;
using Shop.Domain.Models;

//using Shop.Data.Interfaces;
//using Shop.Data.Models;

namespace Shop.Web.Controllers
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

            if (!Enumerable.Any<ShopCartItem>(_shopCart.ListShopItems))
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