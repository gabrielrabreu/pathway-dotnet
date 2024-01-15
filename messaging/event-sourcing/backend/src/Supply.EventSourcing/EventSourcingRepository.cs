using Supply.Domain.Core.Data;
using Supply.Domain.Core.Messaging;
using System.Threading.Tasks;

namespace Supply.EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        public async Task Add<T>(T @event) where T : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                evento.AggregateId.ToString(),
                ExpectedVersion.Any,
                FormatarEvento(evento));
        }
    }
}
