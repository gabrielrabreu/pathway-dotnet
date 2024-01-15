﻿using AutoMapper;
using Supply.Application.DTOs.VeiculoDTOs;
using Supply.Application.DTOs.VeiculoMarcaDTOs;
using Supply.Application.DTOs.VeiculoModeloDTOs;
using Supply.Caching.Entities;

namespace Supply.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<VeiculoCache, VeiculoDTO>();
            CreateMap<VeiculoMarcaCache, VeiculoMarcaDTO>();
            CreateMap<VeiculoModeloCache, VeiculoModeloDTO>();
        }
    }
}
