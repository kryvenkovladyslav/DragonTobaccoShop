using Abstractions.Models;
using Domain.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstractions.BusinessLayer.Services
{
    public interface IProductService
    {
        public Task<Product> CreateNewProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task DeleteProduct(Product product);
        public Task<Product> GetProductByIDAsync(Guid productID);
        public Task<Product> GetProductWithAllDetailsByIDAsync(Guid productID);
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product> GetProductAsync(Guid productID);

    }
}