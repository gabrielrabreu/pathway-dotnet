using MediatR;
using System;

namespace Core.Domain.Events
{
    public abstract class Event : Message, INotification
    {
        protected Event(Guid aggregateId) : base(aggregateId) { }
    }
}
