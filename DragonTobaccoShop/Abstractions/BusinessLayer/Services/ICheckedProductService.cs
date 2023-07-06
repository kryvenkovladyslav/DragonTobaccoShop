using Domain.ApplicationModels;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Abstractions.BusinessLayer.Services
{
    public interface ICheckedProductService
    {
        public Task CreateCheckedProductAsync(CheckedProduct checkedProduct);
        public Task<IEnumerable<CheckedProduct>> GetAllCheckedProductsForUserAsync(Guid userID);
    }
}