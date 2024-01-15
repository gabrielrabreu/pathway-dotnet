using System;

namespace Supply.Domain.Core.Data
{
    public class StoredEvent
    {
        public Guid Id { get; private set; }
        public Guid AggregateId { get; private set; }
        public string Type { get; private set; }
        public DateTime Date { get; private set; }
        public string Data { get; private set; }

        public StoredEvent(Guid aggregateId, string type, DateTime date, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            Type = type;
            Date = date;
            Data = data;
        }
    }
}
