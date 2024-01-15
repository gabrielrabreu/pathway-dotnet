using Core.Domain.CommandHandlers;
using Core.Domain.Common;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using MediatR;
using Something.Domain.Commands.ImportCommands;
using Something.Domain.Events.ImportEvents;
using Something.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Something.Domain.CommandHandlers
{
    public class ImportCommandHandler : CommandHandler,
        IRequestHandler<AddImportCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IImportLayoutRepository _importLayoutRepository;
        private readonly IImportRepository _importRepository;

        public ImportCommandHandler(IMediatorHandler mediatorHandler,
                                    INotificationHandler<DomainNotification> notifications,
                                    IImportLayoutRepository importLayoutRepository,
                                    IImportRepository importRepository)
            : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _importLayoutRepository = importLayoutRepository;
            _importRepository = importRepository;
        }

        public async Task<Unit> Handle(AddImportCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrors(request);
                return Unit.Value;
            }

            if (!(await _importLayoutRepository.Search(x => x.Id == request.Entity.ImportLayoutId)).Any())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(request.MessageType,
                    DomainMessages.NotFound.Format("ImportLayout").Message));
                return Unit.Value;
            }

            request.Entity.Date = DateTime.UtcNow;
            request.Entity.ItemsUnprocessed = request.Entity.ImportItems.Count();
            _importRepository.Add(request.Entity);

            if (await Commit(_importRepository.UnitOfWork))
            {
                await _mediatorHandler.PublishEvent(new ImportAddedEvent(request.Entity.Id));
            }

            return Unit.Value;
        }
    }
}
