using Abstractions.Models;
using Domain.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstractions.BusinessLayer.Services
{
    public interface IWishListService
    {
        public Task<WishList> FindByIDAsync(Guid id);

        public Task<ICollection<Product>> GetAllProductsAsync(Guid id);

        public Task AddProductAsync(Guid id, Product product);

        public Task RemoveProductAsync(Product product);
    }
}