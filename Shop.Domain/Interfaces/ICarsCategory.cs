//using Shop.Data.Models;

using System.Collections.Generic;
using Shop.Domain.Models;

namespace Shop.Domain.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
