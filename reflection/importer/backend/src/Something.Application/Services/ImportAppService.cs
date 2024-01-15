using AutoMapper;
using Core.Application.Services;
using Core.Domain.Common;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using GenericImporter.Service.Exceptions;
using GenericImporter.Service.Extensions;
using MediatR;
using Something.Application.DataTransferObjects.ImportDTOs;
using Something.Application.Interfaces;
using Something.Domain.Commands.ImportCommands;
using Something.Domain.Entities;
using Something.Domain.Events.ImportEvents;
using Something.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Something.Application.Services
{
    public class ImportAppService : AppService<ImportDto, AddImportDto, Import>,
        IImportAppService,
        INotificationHandler<ImportAddedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IImportRepository _importRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly DomainNotificationHandler _notifications;

        public ImportAppService(IMapper mapper,
                                IMediatorHandler mediator,
                                IImportRepository importRepository, 
                                IServiceProvider serviceProvider,
                                INotificationHandler<DomainNotification> notifications)
            : base(mapper, importRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _importRepository = importRepository;
            _serviceProvider = serviceProvider;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public override async Task Add(AddImportDto addImportDto)
        {
            await _mediator.SendCommand(_mapper.Map<AddImportCommand>(addImportDto));
        }

        public async Task Handle(ImportAddedEvent notification, CancellationToken cancellationToken)
        {
            var import = await _importRepository.GetById(notification.AggregateId);
            var importColumns = import.ImportLayout.Columns;

            var importObjectType = Type.GetType(import.ImportLayout.Service.GetDescription());
            var classAttribute = importObjectType.GetImportClassAttribute();
            var service = _serviceProvider.GetService(classAttribute.Class);

            foreach (var item in import.ImportItems)
            {
                var splitted = item.ImportFileLine.Split(import.ImportLayout.Separator);

                if (splitted.Length != importColumns.Count())
                {
                    item.Error = string.Join(", ", "Item doesn't have the same columns as Layout.");
                }
                else
                {
                    var instance = importObjectType.CreateInstance();

                    foreach (var column in importColumns)
                    {
                        try
                        {
                            var property = importObjectType.GetPropertyByImportName(column.Name);
                            property.SetValueByString(instance, splitted[column.Position - 1], column.Format);
                        }
                        catch (ImporterException ex) 
                        {
                            item.Error = ex.Message;    
                        }
                    }

                    if (string.IsNullOrEmpty(item.Error))
                    {
                        await service.CallMethod(classAttribute.Method, instance);

                        if (_notifications.HasNotifications())
                        {
                            item.Error = string.Join(", ", _notifications.GetNotifications().Select(c => c.Value));
                        }
                    }
                }

                item.Processed = true;
                _notifications.ClearNotifications();
            }

            import.ItemsSuccessfullyProcessed = import.ImportItems.Count(x => x.Processed && string.IsNullOrEmpty(x.Error));
            import.ItemsFailedProcessed = import.ImportItems.Count(x => x.Processed && !string.IsNullOrEmpty(x.Error));
            import.ItemsUnprocessed = import.ImportItems.Count(x => !x.Processed);
            import.Processed = import.ItemsUnprocessed == 0;

            if (!await _importRepository.UnitOfWork.Commit())
            {
                await _mediator.PublishDomainNotification(new DomainNotification("Commit",
                    DomainMessages.CommitFailed.Message));
            }
        }
    }
}
