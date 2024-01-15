namespace Supply.EventSourcing
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConnection();
    }
}
