using IdentitySystem.Infrastucture.Services.Implementation;
using IdentitySystem.Infrastucture.Services.Interfaces;
using IdentitySystem.Infrastucture.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace IdentitySystem.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDefaultPasswordValidator<TUser, TKey>(this IServiceCollection services) 
            where TUser : IdentityUser<TKey>
            where TKey : IEquatable<TKey>
        {
            services.TryAddScoped<IPasswordValidator<TUser>, PassowrdValidator<TUser, TKey>>();
        }

        public static void AddDefaultUserValidator<TUser, TKey>(this IServiceCollection services)
            where TUser : IdentityUser<TKey>
            where TKey : IEquatable<TKey>
        {
            services.TryAddScoped<IUserValidator<TUser>, UserValidator<TUser, TKey>>();
        }

        public static void AddDefaultUserService<TUser, TKey>(this IServiceCollection services) 
            where TUser : IdentityUser<TKey>
            where TKey: IEquatable<TKey>
        {
            services.TryAddScoped<IUserService<TUser, TKey>, UserService<TUser, TKey>>();
        }

        public static void AddDefaultRoleService<TRole, TKey>(this IServiceCollection services)
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            services.TryAddScoped<IRoleService<TRole, TKey>, RoleService<TRole, TKey>>();
        }

        public static void AddDefaultUserRoleManager<TUser, TRole, TKey>(this IServiceCollection services)
            where TUser: IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            services.TryAddScoped<IUserRoleManager<TUser, TRole, TKey>, UserRoleManager<TUser, TRole, TKey>>();
        }

        public static void AddDefaultValidators<TUser, TKey>(this IServiceCollection services)
            where TUser : IdentityUser<TKey>
            where TKey : IEquatable<TKey>
        {
            services.AddDefaultPasswordValidator<TUser, TKey>();
            services.AddDefaultUserValidator<TUser, TKey>();
        }

        public static void AddDefaultSevices<TUser, TRole, TKey>(this IServiceCollection services)
            where TUser : IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            services.AddDefaultUserRoleManager<TUser, TRole, TKey>();
            services.AddDefaultUserService<TUser, TKey>();
            services.AddDefaultRoleService<TRole, TKey>();
        }

        public static void AddDefaultIdentitySystemServices<TUser, TRole, TKey>(this IServiceCollection services) 
            where TUser : IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey: IEquatable<TKey>
        {
            services.AddDefaultUserRoleManager<TUser, TRole, TKey>();
            services.AddDefaultPasswordValidator<TUser, TKey>();
            services.AddDefaultUserValidator<TUser, TKey>();
            services.AddDefaultUserService<TUser, TKey>();
            services.AddDefaultRoleService<TRole, TKey>();
        }
    }
}