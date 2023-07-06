using AutoMapper;
using Domain.ApplicationModels;
using WebAPI.Models.DataTransferObjects.Tobacco;

namespace WebAPI.Infrastructure.Mapping.UserMapping
{
    public class TobaccoProfile : Profile
    {
        public TobaccoProfile() 
        {
            CreateMap<Tobacco, TobaccoDTO>();
        }
    }
}
