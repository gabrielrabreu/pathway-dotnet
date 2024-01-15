using AutoMapper;
using Haze.Anything.Application.Interfaces;
using Haze.Anything.Caching.Models;
using Haze.Anything.Domain.Commands.FulanoCommands;
using Haze.Anything.Domain.Entities;
using Haze.Anything.Domain.Repositories;
using Haze.Core.Application.Services;
using Haze.Core.Domain.Common;
using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Haze.Anything.Application.Services
{
    public class FulanoAppService : AppService<FulanoModel>, IFulanoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IFulanoRepository _fulanoRepository;

        public FulanoAppService(IMapper mapper,
                                IMediatorHandler mediatorHandler,
                                IFulanoRepository fulanoRepository)
            : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _fulanoRepository = fulanoRepository;
        }

        public override async Task AddAsync(FulanoModel model)
        {
            var command = new AddFulanoCommand()
            {
                Entity = _mapper.Map<Fulano>(model)
            };

            if (!command.IsValid())
            {
                await RaiseValidationErrorsAsync(command);
                return;
            }

            var listaFulano = await _fulanoRepository.GetAllAsync();

            if (listaFulano.Any(c => c.Id == command.Entity.Id))
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.RegistroExistente.Message));
                return;
            }

            if (listaFulano.Any(c => string.Equals(c.Nome, command.Entity.Nome, StringComparison.CurrentCultureIgnoreCase)))
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.ValorDuplicadoO.Format("Nome").Message));
                return;
            }

            await _mediatorHandler.SendCommandAsync(command);
        }

        public override async Task UpdateAsync(FulanoModel model)
        {
            var command = new UpdateFulanoCommand(model.Id)
            {
                Entity = _mapper.Map<Fulano>(model)
            };

            if (!command.IsValid())
            {
                await RaiseValidationErrorsAsync(command);
                return;
            }

            var dbEntity = await _fulanoRepository.GetByIdAsync(command.Entity.Id);
            if (dbEntity == null)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.RegistroNaoEncontrado.Message));
                return;
            }

            var listaFulano = await _fulanoRepository.GetAllAsync();
            if (listaFulano.Any(c => c.Id != command.Entity.Id && string.Equals(c.Nome, command.Entity.Nome, StringComparison.CurrentCultureIgnoreCase)))
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.ValorDuplicadoO.Format("Nome").Message));
                return;
            }

            _mapper.Map(command.Entity, dbEntity);
            command.Entity = dbEntity;

            await _mediatorHandler.SendCommandAsync(command);
        }

        public override async Task RemoveAsync(Guid id)
        {
            var command = new RemoveFulanoCommand(id);

            if (!command.IsValid())
            {
                await RaiseValidationErrorsAsync(command);
                return;
            }

            if ((await _fulanoRepository.GetByIdAsync(command.AggregateId)) == null)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(new DomainNotification(command.MessageType,
                    CoreUserMessages.RegistroNaoEncontrado.Message));
                return;
            }

            await _mediatorHandler.SendCommandAsync(command);
        }
    }
}