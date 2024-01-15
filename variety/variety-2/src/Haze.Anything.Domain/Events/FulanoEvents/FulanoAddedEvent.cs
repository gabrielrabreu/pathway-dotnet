using Haze.Core.Domain.Events;
using System;

namespace Haze.Anything.Domain.Events.FulanoEvents
{
    public class FulanoUpdatedEvent : DomainEvent
    {
        public FulanoUpdatedEvent(Guid aggregateId)
            : base(aggregateId) { }
    }
}