using MongoDB.Driver;
using Supply.Domain.Core.Data;
using Supply.Domain.Core.Messaging;

namespace Supply.Infra.Data.Context
{
    public class EventSourcingContext
    {
        private readonly IMongoDatabase Database;

        public EventSourcingContext()
        {
            var client = new MongoClient("mongodb://abreu:u472gy3z@localhost:27017/admin");
            Database = client.GetDatabase("Supply");
        }

        public IMongoCollection<StoredEvent> StoredEvents
        {
            get
            {
                return Database.GetCollection<StoredEvent>("StoredEvents");
            }
        }
    }
}
