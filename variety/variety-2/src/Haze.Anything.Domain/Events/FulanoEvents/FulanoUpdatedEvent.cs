using Haze.Core.Domain.Events;
using System;

namespace Haze.Anything.Domain.Events.FulanoEvents
{
    public class FulanoAddedEvent : DomainEvent
    {
        public FulanoAddedEvent(Guid aggregateId)
            : base(aggregateId) { }
    }
}