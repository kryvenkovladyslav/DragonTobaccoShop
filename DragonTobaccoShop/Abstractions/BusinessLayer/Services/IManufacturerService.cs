using Abstractions.BusinessLayer.Services.Base;
using Domain.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstractions.BusinessLayer.Services
{
    public interface IManufacturerService<TModel, TKey> : ICRUDService<TModel>, IFinder<TModel, TKey>
        where TModel : class
        where TKey : IEquatable<TKey>
    {
        public Task<IEnumerable<Manufacturer>> GetManufacturerWithTobaccosAsync(Guid manufacturerID);
    }
}