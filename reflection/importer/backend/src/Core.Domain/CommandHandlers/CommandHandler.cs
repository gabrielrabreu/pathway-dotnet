using Core.Domain.Commands;
using Core.Domain.Common;
using Core.Domain.Interfaces;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Core.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IMediatorHandler mediatorHandler, 
                                 INotificationHandler<DomainNotification> notifications)
        {
            _mediatorHandler = mediatorHandler;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected async Task<bool> Commit(IUnitOfWork uow)
        {
            if (_notifications.HasNotifications())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification("Commit", 
                    DomainMessages.CommitFailed.Message));
                return false;
            }

            if (await uow.Commit()) return true;

            await _mediatorHandler.PublishDomainNotification(new DomainNotification("Commit",
                DomainMessages.CommitFailed.Message));
            return false;
        }

        protected async Task PublishValidationErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(command.MessageType,
                    error.ErrorMessage));
            }
        }
    }
}
