using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Shop.Data.Interfaces;
using Shop.ViewModels;
using Shop.Domain;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }
        public IActionResult Index()
        {
            var homeCars = new HomeViewModel { FavCars = _carRep.GetFavCars };

            return View(homeCars);
        }
    }
}