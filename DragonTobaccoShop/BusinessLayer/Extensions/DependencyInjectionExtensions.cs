using Abstractions.BusinessLayer.Services;
using BusinessLayer.Services;
using Domain.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace BusinessLayer.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddBusinessLayerServices(this IServiceCollection services)
        {
            services.TryAddScoped<IProductService, ProductService>();
            services.TryAddScoped<IWishListService, WishListService>();
            services.TryAddScoped<ICheckedProductService, CheckedProductService>();
            services.TryAddScoped<IManufacturerService<Manufacturer, Guid>, ManufacturerService>();
        }
    }
}
