using AutoMapper;
using FluentValidation.Results;
using Supply.Application.DTOs.VehicleDTOs;
using Supply.Application.Interfaces;
using Supply.Domain.Commands.VehicleCommands;
using Supply.Domain.Core.Data;
using Supply.Domain.Core.Mediator;
using Supply.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supply.Application.Services
{
    public class VehicleAppService : IVehicleAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public VehicleAppService(IMapper mapper,
                                 IMediatorHandler mediator,
                                 IVehicleRepository vehicleRepository, 
                                 IEventSourcingRepository eventSourcingRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _vehicleRepository = vehicleRepository;
            _eventSourcingRepository = eventSourcingRepository;
        }

        public async Task<IEnumerable<VehicleDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<VehicleDTO>>(await _vehicleRepository.GetAll());
        }

        public async Task<VehicleDTO> GetById(Guid id)
        {
            return _mapper.Map<VehicleDTO>(await _vehicleRepository.GetById(id));
        }

        public async Task<IEnumerable<StoredEvent>> GetHistory(Guid id)
        {
            return await _eventSourcingRepository.GetEvents(id);
        }

        public async Task<ValidationResult> Add(AddVehicleDTO addVehicleDTO)
        {
            return await _mediator.SendCommand(_mapper.Map<AddVehicleCommand>(addVehicleDTO));
        }

        public async Task<ValidationResult> Update(UpdateVehicleDTO updateVehicleDTO)
        {
            return await _mediator.SendCommand(_mapper.Map<UpdateVehicleCommand>(updateVehicleDTO));
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            return await _mediator.SendCommand(_mapper.Map<RemoveVehicleCommand>(id));
        }
    }
}
