//using Shop.Data.Models;

using System.Collections.Generic;
using Shop.Domain.Models;

namespace Shop.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavCars { get; set; }
    }
}
