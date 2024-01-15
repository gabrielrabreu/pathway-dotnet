using AutoMapper;
using Haze.Anything.Caching.Models;
using Haze.Anything.Domain.Entities;

namespace Haze.Anything.Infra.AutoMapper
{
    public class AnythingMappingProfile : Profile
    {
        public AnythingMappingProfile()
        {
            CreateMap<Fulano, FulanoModel>().ReverseMap();
            CreateMap<Fulano, Fulano>();
        }
    }
}