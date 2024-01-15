using MediatR;
using Supply.Domain.Core.Data;
using Supply.Domain.Events.VehicleEvents;
using Supply.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Supply.Infra.Data.EventHandlers
{
    public class VehicleEventHandler : 
        INotificationHandler<VehicleAddedEvent>,
        INotificationHandler<VehicleUpdatedEvent>,
        INotificationHandler<VehicleRemovedEvent>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public VehicleEventHandler(IVehicleRepository vehicleRepository,
                                   IEventSourcingRepository eventSourcingRepository)
        {
            _vehicleRepository = vehicleRepository;
            _eventSourcingRepository = eventSourcingRepository;
        }

        public async Task Handle(VehicleAddedEvent notification, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetById(notification.AggregateId);
            await _eventSourcingRepository.SaveEvent(notification, vehicle);
        }

        public async Task Handle(VehicleUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetById(notification.AggregateId);
            await _eventSourcingRepository.SaveEvent(notification, vehicle);
        }

        public async Task Handle(VehicleRemovedEvent notification, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetById(notification.AggregateId);
            await _eventSourcingRepository.RemoveEvents(notification.AggregateId);
        }
    }
}
