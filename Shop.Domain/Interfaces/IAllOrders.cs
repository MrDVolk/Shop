//using Shop.Data.Models;

using Shop.Domain.Models;

namespace Shop.Domain.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
