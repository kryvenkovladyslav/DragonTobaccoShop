using AutoMapper;
using Domain.ApplicationModels;
using WebAPI.Models.DataTransferObjects.Product;

namespace WebAPI.Infrastructure.Mapping.UserMapping
{
    public class CheckedProductProfile : Profile
    {
        public CheckedProductProfile() 
        {
            CreateMap<CheckedProductCreationDTO, CheckedProduct>();
            CreateMap<CheckedProduct, CheckedProductDTO>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Product.Tobacco.Name))
                .ForMember(dest => dest.ImagePath, act => act.MapFrom(src => src.Product.ImagePath));
        }
    }
}