using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models;

//using Shop.Data.Interfaces;
//using Shop.Data.Models;

namespace Shop.DAL.Repository
{
    public class CarRepository : IAllCars
    {

        private readonly AppDBContent _appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => _appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => _appDBContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId)
        {
            return _appDBContent.Car.FirstOrDefault(p => p.Id == carId);
        }
    }
}
