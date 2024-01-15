using Haze.Core.Domain.Commands;
using Haze.Core.Domain.Events;
using Haze.Core.Domain.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Haze.Core.Domain.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> SendCommandAsync<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task RaiseDomainNotificationAsync<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task RaiseDomainEventAsync<T>(T notification) where T : DomainEvent
        {
            await _mediator.Publish(notification);
        }
    }
}