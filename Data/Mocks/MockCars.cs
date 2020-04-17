//using Shop.Data.Interfaces;
//using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {

        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>
                {
                    new Car{Name = "Tesla Model S", ShortDesc = "Fast electro car", LongDesc="Fast and quiet electro car by Tesla",
                        Img = "/img/Tesla.jpg",
                        Price = 45000, IsFavourite = true, Avaliable = true, Category =  _categoryCars.AllCategories.First()},
                    new Car{Name = "Ford Fiesta", ShortDesc = "Quiet car", LongDesc="Quiet car for city driving",
                        Img = "/img/Ford Fiesta.jpg",
                        Price = 11000, IsFavourite = false, Avaliable = true, Category =  _categoryCars.AllCategories.Last()},
                    new Car{Name = "BMW M3", ShortDesc = "Sassy car", LongDesc="Sassy car for real men, you know",
                        Img = "/img/bmw.jpg",
                        Price = 30000, IsFavourite = true, Avaliable = true, Category =  _categoryCars.AllCategories.Last()},
                    new Car{Name = "Mercedes C class", ShortDesc = "Big and comfortable", LongDesc="Comfortable car for businessmen",
                        Img = "/img/Mercedes.jpg",
                        Price = 32000, IsFavourite = false, Avaliable = false, Category =  _categoryCars.AllCategories.Last()},
                    new Car{Name = "Nissan Leaf", ShortDesc = "Quiet and economical", LongDesc="Economical electro car for city driving",
                        Img = "/img/Nissan.jpg",
                        Price = 14000, IsFavourite = true, Avaliable = true, Category =  _categoryCars.AllCategories.First()}
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
