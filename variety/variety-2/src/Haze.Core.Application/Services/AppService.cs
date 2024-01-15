using Haze.Core.Application.Interfaces;
using Haze.Core.Caching.Models;
using Haze.Core.Domain.Commands;
using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace Haze.Core.Application.Services
{
    public abstract class AppService<TModel> : IAppService<TModel> where TModel : Model
    {
        private readonly IMediatorHandler _mediatorHandler;

        protected AppService(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public abstract Task AddAsync(TModel model);

        public abstract Task UpdateAsync(TModel model);

        public abstract Task RemoveAsync(Guid id);

        protected async Task RaiseValidationErrorsAsync(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    error.ErrorMessage));
            }
        }
    }
}