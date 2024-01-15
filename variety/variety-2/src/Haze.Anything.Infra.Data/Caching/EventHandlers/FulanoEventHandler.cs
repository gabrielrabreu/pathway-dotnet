using Haze.Anything.Caching.CacheRepositories;
using Haze.Anything.Domain.Events.FulanoEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Haze.Anything.Infra.Data.Caching.EventHandlers
{
    public class FulanoEventHandler :
        INotificationHandler<FulanoAddedEvent>,
        INotificationHandler<FulanoUpdatedEvent>,
        INotificationHandler<FulanoRemovedEvent>
    {
        private readonly IFulanoCacheRepository _fulanoCacheRepository;

        public FulanoEventHandler(IFulanoCacheRepository fulanoCacheRepository)
        {
            _fulanoCacheRepository = fulanoCacheRepository;
        }

        public async Task Handle(FulanoAddedEvent notification, CancellationToken cancellationToken)
        {
            await _fulanoCacheRepository.AddAsync(notification.AggregateId);
        }

        public async Task Handle(FulanoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await _fulanoCacheRepository.UpdateAsync(notification.AggregateId);
        }

        public async Task Handle(FulanoRemovedEvent notification, CancellationToken cancellationToken)
        {
            await _fulanoCacheRepository.RemoveAsync(notification.AggregateId);
        }
    }
}