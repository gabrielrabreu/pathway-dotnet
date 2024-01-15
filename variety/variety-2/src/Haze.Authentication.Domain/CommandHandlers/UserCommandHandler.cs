using Haze.Authentication.Domain.Commands.UserCommands;
using Haze.Authentication.Domain.Repositories;
using Haze.Core.Domain.CommandHandlers;
using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Haze.Authentication.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<AddUserCommand, bool>,
        IRequestHandler<UpdateUserCommand, bool>,
        IRequestHandler<RemoveUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IMediatorHandler mediatorHandler,
                                  IUserRepository userRepository,
                                  INotificationHandler<DomainNotification> notifications)
            : base(mediatorHandler, userRepository.Uow, notifications)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddUserCommand message, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(message.Entity);

            await Commit();

            return true;
        }

        public async Task<bool> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        {
            _userRepository.Update(message.Entity);

            await Commit();

            return true;
        }

        public async Task<bool> Handle(RemoveUserCommand message, CancellationToken cancellationToken)
        {
            await _userRepository.RemoveAsync(message.AggregateId);

            await Commit();

            return true;
        }
    }
}