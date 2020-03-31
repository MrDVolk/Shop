using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Electromobiles")).OrderBy(i => i.Id);
                    currCategory = "Electromobiles";
                }
                else if (string.Equals("gasoline", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Combustion engine cars")).OrderBy(i => i.Id);
                    currCategory = "Combustion engine cars";
                }
            }

            

            var carObj = new CarsListViewModel { AllCars = cars, CurrCategory = currCategory };

            ViewBag.Title = "Page with automobiles";
            return View(carObj);
        }
    }
}