using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public static class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.Car.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "Fast electro car",
                        LongDesc = "Fast and quiet electro car by Tesla",
                        Img = "/img/Tesla.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Avaliable = true,
                        Category = Categories["Electromobiles"]
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDesc = "Quiet car",
                        LongDesc = "Quiet car for city driving",
                        Img = "/img/Ford Fiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Avaliable = true,
                        Category = Categories["Combustion engine cars"]
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDesc = "Sassy car",
                        LongDesc = "Sassy car for real men, you know",
                        Img = "/img/bmw.jpg",
                        Price = 30000,
                        IsFavourite = true,
                        Avaliable = true,
                        Category = Categories["Combustion engine cars"]
                    },
                    new Car
                    {
                        Name = "Mercedes C class",
                        ShortDesc = "Big and comfortable",
                        LongDesc = "Comfortable car for businessmen",
                        Img = "/img/Mercedes.jpg",
                        Price = 32000,
                        IsFavourite = false,
                        Avaliable = false,
                        Category = Categories["Combustion engine cars"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Quiet and economical",
                        LongDesc = "Economical electro car for city driving",
                        Img = "/img/Nissan.jpg",
                        Price = 14000,
                        IsFavourite = true,
                        Avaliable = true,
                        Category = Categories["Electromobiles"]
                    }
                    );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> _category;

        public static Dictionary<string, Category> Categories {
            get
            {
                if (_category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Electromobiles", Desc = "Modern transport"},
                        new Category {CategoryName = "Combustion engine cars", Desc = "Classical cars, which work on gasoline"}
                    };

                    _category = new Dictionary<string, Category>();
                    foreach (Category element in list)
                    {
                        _category.Add(element.CategoryName, element);
                    }
                }
                return _category;
            }
        }
    }
}
