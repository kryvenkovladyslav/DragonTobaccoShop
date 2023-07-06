using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Infrastructure.Mapping.UserMapping;

namespace WebAPI.Infrastructure.Mapping.DependencyInjection
{
    public static class MapperConfigurationServiceCollectionExtensions
    {
        public static void AddMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<ManufacturerProfile>();
                mc.AddProfile<TobaccoProfile>();
                mc.AddProfile<ProductProfile>();
                mc.AddProfile<UserProfile>();
            });

            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}