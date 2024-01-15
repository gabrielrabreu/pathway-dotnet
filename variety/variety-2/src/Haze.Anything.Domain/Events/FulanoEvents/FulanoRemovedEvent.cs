using Haze.Core.Domain.Events;
using System;

namespace Haze.Anything.Domain.Events.FulanoEvents
{
    public class FulanoRemovedEvent : DomainEvent
    {
        public FulanoRemovedEvent(Guid aggregateId)
            : base(aggregateId) { }
    }
}