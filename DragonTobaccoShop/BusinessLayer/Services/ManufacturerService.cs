using Abstractions.BusinessLayer.Services;
using Abstractions.DataAccessLayer.Repository;
using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ManufacturerService : IManufacturerService<Manufacturer, Guid>
    {
        private readonly IRepository<Manufacturer> manufacturerRepository;

        public ManufacturerService(IRepository<Manufacturer> manufacturerRepository) 
        {
            this.manufacturerRepository = manufacturerRepository;
        }

        public async  Task<Manufacturer> CreateAsync(Manufacturer model)
        {
            return await manufacturerRepository.CreateAsync(model);
        }

        public async Task<Manufacturer> UpdateAsync(Manufacturer model)
        {
            return await manufacturerRepository.UpdateAsync(model);
        }

        public async Task DeleteAsync(Manufacturer model)
        {
            await manufacturerRepository.DeleteAsync(model);
        }

        public async Task<Manufacturer> FindByIDAsync(Guid key)
        {
            return await manufacturerRepository.FindByIDAsync(key);
        }

        public async Task<Manufacturer> FirstOrDefaultAsync(Expression<Func<Manufacturer, bool>> predicate)
        {
            return await manufacturerRepository.FirstOrDefautAsync(predicate);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return await manufacturerRepository.GetAllAsync();
        }

        public async Task<bool> IsAlreadyExist(Manufacturer model)
        {
            var manufacturer = await manufacturerRepository.FirstOrDefautAsync(m => m.Name == model.Name);
            return manufacturer != null;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturerWithTobaccosAsync(Guid manufacturerID)
        {
            return await manufacturerRepository.GetQueryable()
                .Include(m => m.Tobaccos)
                .Where(m => m.ID == manufacturerID)
                .ToListAsync();
        }
    }
}