using MediatR;
using System;

namespace Haze.Core.Domain.Events
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}