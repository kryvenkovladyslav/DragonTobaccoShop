using AutoMapper;
using Domain.ApplicationModels;
using WebAPI.Models.DataTransferObjects.User;

namespace WebAPI.Infrastructure.Mapping.UserMapping
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationUserDTO, User>();
            CreateMap<LoginUserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}