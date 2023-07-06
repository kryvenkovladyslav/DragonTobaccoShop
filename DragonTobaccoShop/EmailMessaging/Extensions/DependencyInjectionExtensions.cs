using EmailMessaging.Common.Services.Implementaion;
using EmailMessaging.Common.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EmailMessaging.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDefaultEmailManagerService(this IServiceCollection services)
        {
            services.TryAddScoped<IEmailManagerService, EmailManagerService>();
        }

        public static void AddEmailManagerService<TService>(this IServiceCollection services)
            where TService : class, IEmailManagerService
        {
            services.TryAddScoped<IEmailManagerService, TService>();
        }

        public static void AddEmailMessaging(this IServiceCollection services)
        {
            services.AddDefaultEmailManagerService();
        }
    }
}