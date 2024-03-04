using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Order GetOrderByID(int id);
        Task<Order> AddOrderAsync(Order order);
        Order UpdateOrder(int id, Order order);
        void DeleteOrder(int id);
    }
}
