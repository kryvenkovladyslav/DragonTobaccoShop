using Abstractions.BusinessLayer.Services;
using Abstractions.DataAccessLayer.Repository;
using Abstractions.Models;
using Domain.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class WishListService : IWishListService
    {
        private readonly IRepository<WishList> wishListRepository;
        private readonly IRepository<Product> productRepository;
             
        public WishListService(IRepository<WishList> wishListRepository, IRepository<Product> productRepository)
        {
            this.wishListRepository = wishListRepository;
            this.productRepository = productRepository;
        }

        public async Task<WishList> FindByIDAsync(Guid id)
        {
            return await wishListRepository.FindByIDAsync(id);
        }

        public async Task<ICollection<Product>> GetAllProductsAsync(Guid id)
        {
            return await productRepository.FilterAsync(p => p.ID == id);
        }

        public async Task AddProductAsync(Guid id, Product product) 
        {
            var requiredProduct = await productRepository.FindByIDAsync(product.ID);
            requiredProduct.WishListID = id;

            await  productRepository.UpdateAsync(requiredProduct);
        }

        public async Task RemoveProductAsync(Product product)
        {
            var requiredProduct = await productRepository.FindByIDAsync(product.ID);
            requiredProduct.WishListID = null;

            await productRepository.UpdateAsync(requiredProduct);
        }
    }
}