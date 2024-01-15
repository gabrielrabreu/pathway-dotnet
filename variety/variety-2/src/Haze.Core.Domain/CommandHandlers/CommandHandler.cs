using Haze.Core.Domain.Common;
using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using Haze.Core.Domain.Uow;
using MediatR;
using System.Threading.Tasks;

namespace Haze.Core.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _mediatorHandler;
        protected readonly IUnitOfWork _uow;
        private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IMediatorHandler mediatorHandler,
                                 IUnitOfWork uow,
                                 INotificationHandler<DomainNotification> notifications)
        {
            _mediatorHandler = mediatorHandler;
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected async Task<bool> Commit()
        {
            if (_notifications.HasNotifications())
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification("Commit",
                    CoreUserMessages.ErroPersistenciaDados.Message));
                return false;
            }

            if (await _uow.CommitAsync()) return true;

            await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification("Commit",
                CoreUserMessages.ErroPersistenciaDados.Message));
            return false;
        }
    }
}