﻿using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Core.Service;
using Solid.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable <Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddProductAsync(product);
        }
        public Product UpdateProduct(int id, Product product)
        {
            return _productRepository.UpdateProduct(id, product);
        }
        public Product UpdateProductPrice(int id, int price)
        {
            return _productRepository.UpdateProductPrice(id, price);
        }
        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
