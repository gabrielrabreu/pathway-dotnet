﻿using FluentValidation.Results;
using MediatR;
using Supply.Domain.Commands.VehicleCommands;
using Supply.Domain.Core.Domain;
using Supply.Domain.Core.Mediator;
using Supply.Domain.Core.Messaging;
using Supply.Domain.Entities;
using Supply.Domain.Events.VehicleEvents;
using Supply.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Supply.Domain.CommandHandlers
{
    public class VehicleCommandHandler : CommandHandler,
        IRequestHandler<AddVehicleCommand, ValidationResult>,
        IRequestHandler<UpdateVehicleCommand, ValidationResult>,
        IRequestHandler<RemoveVehicleCommand, ValidationResult>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleCommandHandler(IMediatorHandler mediatorHandler, 
                                     IVehicleRepository vehicleRepository)
        {
            _mediatorHandler = mediatorHandler;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<ValidationResult> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var vehicle = new Vehicle(request.Plate);

            if ((await _vehicleRepository.Search(x => x.Plate == vehicle.Plate)).Any())
            {
                AddError(DomainMessages.AlreadyInUse.Format("Plate").Message);
                return ValidationResult;
            }

            _vehicleRepository.Add(vehicle);

            if (await Commit(_vehicleRepository.UnitOfWork))
            {
                await _mediatorHandler.PublishEvent(new VehicleAddedEvent(vehicle.Id));
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var vehicle = await _vehicleRepository.GetById(request.AggregateId);
            if (vehicle == null)
            {
                AddError(DomainMessages.NotFound.Format("Vehicle").Message);
                return ValidationResult;
            }

            if ((await _vehicleRepository.Search(x => x.Plate == request.Plate && x.Id != request.AggregateId)).Any())
            {
                AddError(DomainMessages.AlreadyInUse.Format("Plate").Message);
                return ValidationResult;
            }

            vehicle.UpdatePlate(request.Plate);
            _vehicleRepository.Update(vehicle);

            if (await Commit(_vehicleRepository.UnitOfWork))
            {
                await _mediatorHandler.PublishEvent(new VehicleUpdatedEvent(vehicle.Id));
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(RemoveVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var vehicle = await _vehicleRepository.GetById(request.AggregateId);
            if (vehicle == null)
            {
                AddError(DomainMessages.NotFound.Format("Vehicle").Message);
                return ValidationResult;
            }

            _vehicleRepository.Remove(vehicle);

            if (await Commit(_vehicleRepository.UnitOfWork))
            {
                await _mediatorHandler.PublishEvent(new VehicleRemovedEvent(request.AggregateId));
            }

            return ValidationResult;
        }
    }
}
