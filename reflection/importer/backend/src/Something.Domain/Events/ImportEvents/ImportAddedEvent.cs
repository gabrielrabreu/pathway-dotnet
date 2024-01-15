using Core.Domain.Events;
using System;

namespace Something.Domain.Events.ImportEvents
{
    public class ImportAddedEvent : Event
    {
        public ImportAddedEvent(Guid aggregateId) : base(aggregateId) { }
    }
}
