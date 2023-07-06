using Abstractions.Models;
using AutoMapper;
using WebAPI.Models.DataTransferObjects.Product;

namespace WebAPI.Infrastructure.Mapping.UserMapping
{
    public sealed class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductCreationDTO, Product>()
                .ForMember(dest => dest.ID, act => act.MapFrom(src => src.Tobacco.ID))
                .ForMember(dest => dest.Tobacco, act => act.MapFrom(src => src.Tobacco));

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Tobacco.Name));

            CreateMap<Product, MainProduct>()
                .ForMember(dest => dest.Tobacco, act => act.MapFrom(src => src.Tobacco));
        }
    }
}