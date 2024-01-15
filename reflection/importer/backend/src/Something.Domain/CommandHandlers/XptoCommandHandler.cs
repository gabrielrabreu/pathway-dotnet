using Core.Domain.CommandHandlers;
using Core.Domain.Common;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using MediatR;
using Something.Domain.Commands.XptoCommands;
using Something.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Something.Domain.CommandHandlers
{
    public class XptoCommandHandler : CommandHandler,
        IRequestHandler<AddXptoCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IXptoRepository _xptoRepository;

        public XptoCommandHandler(IMediatorHandler mediatorHandler,
                                  INotificationHandler<DomainNotification> notifications, 
                                  IXptoRepository xptoRepository)
            : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _xptoRepository = xptoRepository;
        }

        public async Task<Unit> Handle(AddXptoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrors(request);
                return Unit.Value;
            }

            if ((await _xptoRepository.Search(x => x.Name == request.Entity.Name)).Any())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(request.MessageType,
                    DomainMessages.AlreadyInUse.Format("Name").Message));
                return Unit.Value;
            }

            _xptoRepository.Add(request.Entity);

            await Commit(_xptoRepository.UnitOfWork);

            return Unit.Value;
        }
    }
}
