using Microsoft.EntityFrameworkCore;
//using Shop.Data.Interfaces;
//using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain;

namespace Shop.DAL
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
