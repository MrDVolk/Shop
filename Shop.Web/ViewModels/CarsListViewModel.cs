//using Shop.Data.Models;

using System.Collections.Generic;
using Shop.Domain.Models;

namespace Shop.Web.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }

        public string CurrCategory { get; set; }
    }
}
