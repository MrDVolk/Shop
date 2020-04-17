//using Shop.Data.Interfaces;
//using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            {
                return new List<Category>
                {
                new Category { CategoryName = "Electromobiles", Desc = "Modern transport"},
                new Category {CategoryName = "Combustion engine cars", Desc = "Classical cars, which work on gasoline"}
                };
            }
        }



    }
}
