using AutoMapper;
using Haze.Authentication.Application.Interfaces;
using Haze.Authentication.Caching.Models;
using Haze.Authentication.Domain.Commands.UserCommands;
using Haze.Authentication.Domain.Entities;
using Haze.Authentication.Domain.Repositories;
using Haze.Authentication.Web.JwtBearer;
using Haze.Authentication.Web.PasswordHashing;
using Haze.Core.Application.Services;
using Haze.Core.Domain.Common;
using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Haze.Authentication.Application.Services
{
    public class UserAppService : AppService<UserModel>, IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper,
                              IMediatorHandler mediatorHandler,
                              IUserRepository UserRepository)
            : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _userRepository = UserRepository;
        }

        public override async Task AddAsync(UserModel model)
        {
            var command = new AddUserCommand()
            {
                Entity = _mapper.Map<User>(model)
            };

            if (!command.IsValid())
            {
                await RaiseValidationErrorsAsync(command);
                return;
            }

            var listaUser = await _userRepository.GetAllAsync();

            if (listaUser.Any(c => c.Id == command.Entity.Id))
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.RegistroExistente.Message));
                return;
            }

            if (listaUser.Any(c => string.Equals(c.Username, command.Entity.Username, StringComparison.CurrentCultureIgnoreCase)))
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.ValorDuplicadoO.Format("Username").Message));
                return;
            }

            command.Entity.Password = PasswordHashService.Hash(command.Entity.Password);

            await _mediatorHandler.SendCommandAsync(command);
        }

        public override async Task UpdateAsync(UserModel model)
        {
            var command = new UpdateUserCommand(model.Id)
            {
                Entity = _mapper.Map<User>(model)
            };

            if (!command.IsValid())
            {
                await RaiseValidationErrorsAsync(command);
                return;
            }

            var dbEntity = await _userRepository.GetByIdAsync(command.Entity.Id);
            if (dbEntity == null)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.RegistroNaoEncontrado.Message));
                return;
            }

            var listaUser = await _userRepository.GetAllAsync();
            if (listaUser.Any(c => c.Id != command.Entity.Id && string.Equals(c.Username, command.Entity.Username, StringComparison.CurrentCultureIgnoreCase)))
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.ValorDuplicadoO.Format("Username").Message));
                return;
            }

            command.Entity.Password = PasswordHashService.Hash(command.Entity.Password);
            _mapper.Map(command.Entity, dbEntity);
            command.Entity = dbEntity;

            await _mediatorHandler.SendCommandAsync(command);
        }

        public override async Task RemoveAsync(Guid id)
        {
            var command = new RemoveUserCommand(id);

            if (!command.IsValid())
            {
                await RaiseValidationErrorsAsync(command);
                return;
            }

            if ((await _userRepository.GetByIdAsync(command.AggregateId)) == null)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.RegistroNaoEncontrado.Message));
                return;
            }

            await _mediatorHandler.SendCommandAsync(command);
        }

        public string Login(UserModel model)
        {
            var dbEntity = _userRepository.GetByCredentials(model.Username, model.Password);

            if (dbEntity == null)
            {
                return null;
            }

            return JwtBearerTokenService.GenerateToken(_mapper.Map<User>(model));
        }
    }
}