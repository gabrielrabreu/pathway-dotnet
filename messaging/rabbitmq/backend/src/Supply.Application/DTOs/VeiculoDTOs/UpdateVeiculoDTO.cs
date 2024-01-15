﻿using Supply.Application.Core.Application;
using System;

namespace Supply.Application.DTOs.VeiculoDTOs
{
    public class UpdateVeiculoDTO : DTO
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataAquisicao { get; set; }
        public double ValorAquisicao { get; set; }
        public Guid VeiculoModeloId { get; set; }
    }
}
