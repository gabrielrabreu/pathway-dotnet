using Haze.Core.Domain.Commands;
using Haze.Core.Domain.Events;
using Haze.Core.Domain.Notifications;
using System.Threading.Tasks;

namespace Haze.Core.Domain.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommandAsync<T>(T command) where T : Command;

        Task RaiseDomainNotificationAsync<T>(T notification) where T : DomainNotification;

        Task RaiseDomainEventAsync<T>(T notification) where T : DomainEvent;
    }
}