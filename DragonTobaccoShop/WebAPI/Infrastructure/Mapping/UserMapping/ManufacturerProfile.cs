using AutoMapper;
using Domain.ApplicationModels;
using System;
using WebAPI.Models.DataTransferObjects.Manufacturer;

namespace WebAPI.Infrastructure.Mapping.UserMapping
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile() 
        {
            CreateMap<ManufacturerCreationDTO, Manufacturer>();
            CreateMap<UpdateManufaturerDTO<Guid>, Manufacturer>();
            CreateMap<Manufacturer, ManufacturerDTO<Guid>>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerWithTobaccoDTO>()
                .ForMember(dest => dest.Tobaccos, act => act.MapFrom(src => src.Tobaccos));
        }
    }
}