using System.Linq.Expressions;

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

        public Task<TEntity> FindByID<TKey>(TKey id) where TKey : struct;

        public Task<TEntity> FirstOrDefaut(Expression<Func<TEntity, bool>> predicate);

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public int GetTotalCount();
    }
}