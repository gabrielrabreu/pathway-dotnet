using System;

namespace Haze.Core.Domain.Events
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message(Guid aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
        }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}