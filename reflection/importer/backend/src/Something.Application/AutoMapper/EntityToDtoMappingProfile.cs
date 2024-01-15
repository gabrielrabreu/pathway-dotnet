using AutoMapper;
using Something.Application.DataTransferObjects.ImportDTOs;
using Something.Application.DataTransferObjects.ImportLayoutDTOs;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Domain.Entities;

namespace Something.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Xpto, XptoDto>();
            CreateMap<ImportLayout, ImportLayoutDto>();
            CreateMap<ImportLayoutColumn, ImportLayoutColumnDto>();
            CreateMap<Import, ImportDto>();
            CreateMap<ImportItem, ImportItemDto>();
        }
    }
}
