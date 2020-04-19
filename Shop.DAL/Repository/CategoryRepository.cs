//using Shop.Data.Interfaces;
//using Shop.Data.Models;

using System.Collections.Generic;
using Shop.Domain.Interfaces;
using Shop.Domain.Models;

namespace Shop.DAL.Repository
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
