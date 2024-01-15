using MongoDB.Driver;
using Newtonsoft.Json;
using Supply.Domain.Core.Data;
using Supply.Domain.Core.Messaging;
using Supply.Domain.Core.Messaging.Domain;
using Supply.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Infra.Data.EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly EventSourcingContext _eventSourcingContext;

        public EventSourcingRepository(EventSourcingContext eventSourcingContext)
        {
            _eventSourcingContext = eventSourcingContext;
        }

        public async Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId)
        {
            return await _eventSourcingContext.StoredEvents.Find(e => e.AggregateId == aggregateId).ToListAsync();
        }

        public async Task SaveEvent<TEvent, TEntity>(TEvent @event, TEntity entity)
            where TEvent : Event
            where TEntity : Entity
        {
            var storedEvent = new StoredEvent(@event.AggregateId, @event.MessageType, @event.Timestamp, JsonConvert.SerializeObject(entity));
            await _eventSourcingContext.StoredEvents.InsertOneAsync(storedEvent);
        }

        public async Task RemoveEvents(Guid aggregateId)
        {
            await _eventSourcingContext.StoredEvents.DeleteManyAsync(e => e.AggregateId == aggregateId);
        }
    }
}
