using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Abstractions.DataAccessLayer.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> CreateAsync(TEntity entity);

        public Task CreateRangeAsync(params TEntity[] entities);

        public Task<TEntity> UpdateAsync(TEntity entity);

        public void UpdateRange(params TEntity[] entities);

        public Task DeleteAsync(TEntity entity);

        public void DeleteRange(params TEntity[] entities);

        public Task<TEntity> FindByIDAsync<TKey>(TKey id) where TKey : IEquatable<TKey>;

        public Task<TEntity> FirstOrDefautAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<ICollection<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);

        public IQueryable<TEntity> GetQueryable();

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public int GetTotalCount();
    }
}