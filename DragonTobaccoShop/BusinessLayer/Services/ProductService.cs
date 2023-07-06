using Abstractions.BusinessLayer.Services;
using Abstractions.DataAccessLayer.Repository;
using Abstractions.Models;
using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public virtual async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await productRepository.GetQueryable().Include(p=> p.Tobacco).ToArrayAsync();
        }

        public virtual async Task<Product> GetProductByIDAsync(Guid productID)
        {
            return await productRepository.FindByIDAsync(productID);
        }

        public virtual async Task<Product> GetProductWithAllDetailsByIDAsync(Guid productID)
        {
            /*return await productRepository.GetQueryable()
                .Include(p => p.Tobacco)
                .ThenInclude(t => t.Manufacturer)
                .Where(p => p.ID == productID)
                .FirstOrDefaultAsync();*/
            throw new NotImplementedException();
        }

        public virtual async Task<Product> CreateNewProduct(Product product)
        {
            try
            {
                return await productRepository.CreateAsync(product);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public virtual async Task<Product> GetProductAsync(Guid productID)
        {
            return await productRepository.GetQueryable().Include(p => p.Tobacco).FirstAsync(p => p.ID == productID);
        }
        public virtual async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                return await productRepository.UpdateAsync(product);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public virtual async Task DeleteProduct(Product product)
        {
            try 
            {
                await productRepository.DeleteAsync(product);
            }
            catch(Exception exception)
            {
                throw;
            }
        }
    }
}