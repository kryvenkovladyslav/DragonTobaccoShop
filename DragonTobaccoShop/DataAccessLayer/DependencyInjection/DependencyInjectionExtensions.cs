using Abstractions.DataAccessLayer.Repository;
using Abstractions.Models;
using DataAccessLayer.Common.Repository;
using Domain.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DataAccessLayer.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void TryAddScopedRepository<TEntity>(this IServiceCollection services) where TEntity : class
        {
            services.TryAddScoped<IRepository<TEntity>, Repository<TEntity>>();
        }
        
        public static void TryAddScopedAllApplicationRepositories(this IServiceCollection services)
        {
            services.TryAddScopedRepository<CheckedProduct>();
            services.TryAddScopedRepository<Manufacturer>();
            services.TryAddScopedRepository<Order>();
            services.TryAddScopedRepository<OrderItem>();
            services.TryAddScopedRepository<Product>();
            services.TryAddScopedRepository<Review>();
            services.TryAddScopedRepository<Role>();
            services.TryAddScopedRepository<Strength>();
            services.TryAddScopedRepository<Taste>();
            services.TryAddScopedRepository<Tobacco>();
            services.TryAddScopedRepository<TobaccosTastes>();
            services.TryAddScopedRepository<User>();
            services.TryAddScopedRepository<WishList>();
            services.TryAddScopedRepository<CartSession>();
        }
    }
}