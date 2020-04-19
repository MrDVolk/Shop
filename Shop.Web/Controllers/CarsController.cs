using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.DAL;
using Shop.Domain.Interfaces;
using Shop.Domain.Models;
using Shop.Web.ViewModels;

//using Shop.Data.Interfaces;
//using Shop.Data.Models;

namespace Shop.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        private readonly Dictionary<string, string> _categoriesRoutes = new Dictionary<string, string>();

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;

            _categoriesRoutes.Add("electro", DBObjects.Electromobiles.CategoryName);
            _categoriesRoutes.Add("gasoline", DBObjects.CombustionEngineCars.CategoryName);
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
                if (_categoriesRoutes.ContainsKey(category))
                {
                    _categoriesRoutes.TryGetValue(category, out currCategory);
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals(currCategory)).OrderBy(i => i.Id);
                }
            }

            

            var carObj = new CarsListViewModel { AllCars = cars, CurrCategory = currCategory };

            ViewBag.Title = "Page with automobiles";
            return View(carObj);
        }
    }
}