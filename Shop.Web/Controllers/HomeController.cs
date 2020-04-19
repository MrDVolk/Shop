using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interfaces;
using Shop.Web.ViewModels; //using Shop.Data.Interfaces;

namespace Shop.Web.Controllers
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