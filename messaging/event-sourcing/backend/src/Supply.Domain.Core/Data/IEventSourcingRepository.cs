using Supply.Domain.Core.Messaging;
using Supply.Domain.Core.Messaging.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supply.Domain.Core.Data
{
    public interface IEventSourcingRepository
    {
        Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId);

        Task SaveEvent<TEvent, TEntity>(TEvent @event, TEntity entity) where TEvent : Event where TEntity : Entity;
        Task RemoveEvents(Guid aggregateId);
    }
}
