using Haze.Anything.Domain.Commands.FulanoCommands;
using Haze.Anything.Domain.Events.FulanoEvents;
using Haze.Anything.Domain.Repositories;
using Haze.Core.Domain.CommandHandlers;
using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Haze.Anything.Domain.CommandHandlers
{
    public class FulanoCommandHandler : CommandHandler,
        IRequestHandler<AddFulanoCommand, bool>,
        IRequestHandler<UpdateFulanoCommand, bool>,
        IRequestHandler<RemoveFulanoCommand, bool>
    {
        private readonly IFulanoRepository _fulanoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public FulanoCommandHandler(IMediatorHandler mediatorHandler,
                                    IFulanoRepository fulanoRepository,
                                    INotificationHandler<DomainNotification> notifications)
            : base(mediatorHandler, fulanoRepository.Uow, notifications)
        {
            _fulanoRepository = fulanoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AddFulanoCommand message, CancellationToken cancellationToken)
        {
            await _fulanoRepository.AddAsync(message.Entity);

            if (await Commit())
            {
                await _mediatorHandler.RaiseDomainEventAsync(new FulanoAddedEvent(message.Entity.Id));
            }

            return true;
        }

        public async Task<bool> Handle(UpdateFulanoCommand message, CancellationToken cancellationToken)
        {
            _fulanoRepository.Update(message.Entity);

            if (await Commit())
            {
                await _mediatorHandler.RaiseDomainEventAsync(new FulanoUpdatedEvent(message.Entity.Id));
            }

            return true;
        }

        public async Task<bool> Handle(RemoveFulanoCommand message, CancellationToken cancellationToken)
        {
            await _fulanoRepository.RemoveAsync(message.AggregateId);

            if (await Commit())
            {
                await _mediatorHandler.RaiseDomainEventAsync(new FulanoRemovedEvent(message.Entity.Id));
            }

            return true;
        }
    }
}