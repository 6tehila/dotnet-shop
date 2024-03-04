using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            //return _context.Orders;

            // בקשת ה GetOrderById מביאה את ההזמנה וכוללת את רשימת המוצרים באופן ישיר
            return await _context.Orders
                .Include(o => o.Provider).ToListAsync(); // Include רשימת המוצרים
              //  .FirstOrDefault(o => o.Id == id); // מצא את ההזמנה לפי המזהה

        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public Order UpdateOrder(int id, Order order)
        {
            Order order1 = _context.Orders.ToList().Find(x => x.Id == id);
            if (order1 != null)
            {
                order1.SumOrder = order.SumOrder;
               // order1.Provider = order.Provider;
                order1.Products= order.Products;
            }
            _context.SaveChanges();
            return order1;

        }
        public void DeleteOrder(int id)
        {
            _context.Orders.Remove(_context.Orders.ToList().Find(x => x.Id == id));
            _context.SaveChanges();

        }
    }
}
