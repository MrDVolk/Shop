//using Shop.Data.Models;

using System.Collections.Generic;
using Shop.Domain.Models;

namespace Shop.Domain.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavCars { get;}
        Car GetObjectCar(int carId);
    }
}
