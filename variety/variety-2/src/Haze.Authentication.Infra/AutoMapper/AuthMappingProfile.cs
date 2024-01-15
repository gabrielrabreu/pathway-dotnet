using AutoMapper;
using Haze.Authentication.Caching.Models;
using Haze.Authentication.Domain.Entities;

namespace Haze.Authentication.Infra.AutoMapper
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, User>();
        }
    }
}