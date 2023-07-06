using Abstractions.DataAccessLayer.Repository;
using DataAccessLayer.Common.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Common.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext context;

        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var property = entity.GetType().GetProperties()
                .Where(p => p.Name.ToLower() == "id" && p.PropertyType == typeof(Guid))
                .FirstOrDefault();

            if (property != null)
            {
                property.SetValue(entity, Guid.Empty);
            }
            var result = (await context.Set<TEntity>().AddAsync(entity)).Entity;

            context.SaveChanges();

            return result;
        }

        public async Task CreateRangeAsync(params TEntity[] entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
            context.SaveChanges();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = (await Task.FromResult(context.Set<TEntity>().Update(entity))).Entity;
            context.SaveChanges();

            return result;
        }

        public void UpdateRange(params TEntity[] entities)
        {
            context.Set<TEntity>().UpdateRange(entities);
            context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var result = context.Set<TEntity>().Remove(entity);
            context.SaveChanges();

            await Task.FromResult(result);
        }

        public void DeleteRange(params TEntity[] entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }

        public async Task<TEntity> FindByIDAsync<TKey>(TKey id) where TKey : IEquatable<TKey>
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FirstOrDefautAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public int GetTotalCount()
        {
            return context.Set<TEntity>().Count();
        }

        public async Task<ICollection<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}