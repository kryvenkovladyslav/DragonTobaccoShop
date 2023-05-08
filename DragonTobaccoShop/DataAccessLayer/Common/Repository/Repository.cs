using Abstractions.DataAccessLayer.Repository;
using DataAccessLayer.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            
            if(property != null) 
            {
                property.SetValue(entity, Guid.Empty);
            }

            return (await context.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task CreateRangeAsync(params TEntity[] entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return (await Task.FromResult(context.Set<TEntity>().Update(entity))).Entity;
        }

        public void UpdateRange(params TEntity[] entities)
        {
            context.Set<TEntity>().UpdateRange(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(context.Set<TEntity>().Remove(entity));
        }

        public void DeleteRange(params TEntity[] entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> FindByID<TKey>(TKey id) where TKey: struct
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FirstOrDefaut(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public int GetTotalCount()
        {
            return context.Set<TEntity>().Count();
        } 
    }
}