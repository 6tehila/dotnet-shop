using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Product GetProductById(int id);
        Task<Product> AddProductAsync(Product product);
        Product UpdateProduct(int id, Product product);
        Product UpdateProductPrice(int id, int price);
        void DeleteProduct(int id);

    }
}
