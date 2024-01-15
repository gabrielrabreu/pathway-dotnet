using Core.Domain.Commands;
using Core.Domain.Events;
using Core.Domain.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Core.Domain.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<Unit> SendCommand<T>(T command) where T : Command;
        Task PublishDomainNotification<T>(T notification) where T : DomainNotification;
    }
}
