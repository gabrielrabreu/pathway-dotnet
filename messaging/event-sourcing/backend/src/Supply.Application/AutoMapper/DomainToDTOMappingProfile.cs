using AutoMapper;
using Supply.Application.DTOs.VehicleDTOs;
using Supply.Domain.Entities;

namespace Supply.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Vehicle, VehicleDTO>();
        }
    }
}
