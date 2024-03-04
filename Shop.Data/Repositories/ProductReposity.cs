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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.ToList().Find(x => x.Id == id);
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        }
        public Product UpdateProduct(int id, Product product)
        {
            Product product1 = _context.Products.ToList().Find(x => x.Id == id);
            if (product1 != null)
            {
                product1.Price = product.Price;
                product1.Quantity = product.Quantity;
                product1.Name = product.Name;
            }
            _context.SaveChanges();
            return product1;

        }
        public Product UpdateProductPrice(int id, int price)
        {
            Product product = _context.Products.ToList().Find(x => x.Id == id);
            if (product != null)
                _context.Products.Find(id).Price = price;
            _context.SaveChanges();
            return product;

        }
        public void DeleteProduct(int id)
        {
            Product p = _context.Products.ToList().Find(x => x.Id == id);
            if (p != null)
                _context.Products.Remove(p);
            _context.SaveChanges();
        }
    }
}
