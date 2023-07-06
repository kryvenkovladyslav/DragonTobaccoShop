using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Abstractions.BusinessLayer.Services.Base
{
    public interface IFinder<TModel, TKey> 
        where TModel : class
        where TKey : IEquatable<TKey>   
    {
        public Task<IEnumerable<TModel>> GetAllAsync();

        public Task<TModel> FindByIDAsync(TKey key);

        public Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate);
    }
}