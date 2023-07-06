using Abstractions.BusinessLayer.Services;
using Abstractions.DataAccessLayer.Repository;
using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CheckedProductService : ICheckedProductService
    {
        private readonly IRepository<CheckedProduct> checkedProductRepository;

        public CheckedProductService(IRepository<CheckedProduct> checkedProductRepository)
        {
            this.checkedProductRepository = checkedProductRepository;
        }

        public async Task CreateCheckedProductAsync(CheckedProduct checkedProduct)
        {
            await checkedProductRepository.CreateAsync(checkedProduct);
        }

        public async Task<IEnumerable<CheckedProduct>> GetAllCheckedProductsForUserAsync(Guid userID)
        {
            return await checkedProductRepository.GetQueryable()
                .Include(t => t.Product)
                .ThenInclude(p => p.Tobacco)
                .Where(cp => cp.UserID == userID)
                .ToListAsync();
        }
    }
}