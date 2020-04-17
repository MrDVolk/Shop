//using Shop.Data.Interfaces;
//using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain;

namespace Shop.DAL
{
    public class CategoryRepository : ICarsCategory
    {

        private readonly AppDBContent _appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => _appDBContent.Category;
    }
}
