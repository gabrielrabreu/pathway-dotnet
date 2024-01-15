using Core.Domain.CommandHandlers;
using Core.Domain.Common;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using GenericImporter.Service.Attributes;
using MediatR;
using Something.Domain.Commands.ImportLayoutCommands;
using Something.Domain.Common;
using Something.Domain.Entities;
using Something.Domain.Enums;
using Something.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Something.Domain.CommandHandlers
{
    public class ImportLayoutCommandHandler : CommandHandler,
        IRequestHandler<AddImportLayoutCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IImportLayoutRepository _importLayoutRepository;
        private readonly IImportFieldRetriever _importFieldRetriever;

        public ImportLayoutCommandHandler(IMediatorHandler mediatorHandler,
                                          INotificationHandler<DomainNotification> notifications,
                                          IImportLayoutRepository importLayoutRepository, 
                                          IImportFieldRetriever importFieldRetriever)
            : base(mediatorHandler, notifications)
        {
            _mediatorHandler = mediatorHandler;
            _importLayoutRepository = importLayoutRepository;
            _importFieldRetriever = importFieldRetriever;
        }

        public async Task<Unit> Handle(AddImportLayoutCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrors(request);
                return Unit.Value;
            }

            if ((await _importLayoutRepository.Search(x => x.Name == request.Entity.Name)).Any())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(request.MessageType,
                    DomainMessages.AlreadyInUse.Format("Name").Message));
                return Unit.Value;
            }

            if (!await ValidateIfColumsAreValid(request.MessageType, request.Entity.Service, request.Entity.Columns))
            {
                return Unit.Value;
            }

            _importLayoutRepository.Add(request.Entity);

            await Commit(_importLayoutRepository.UnitOfWork);

            return Unit.Value;
        }

        private async Task<bool> ValidateIfColumsAreValid(string messageType,
                                                          ImportLayoutService importLayoutService,
                                                          IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            if (!await ValidateIfColumnsPositionAreValid(messageType, importLayoutColumns))
            {
                return false;
            }

            if (!await ValidateIfColumnNameRepeat(messageType, importLayoutColumns))
            {
                return false;
            }

            if (!await ValidateIfColumnNameExists(messageType, importLayoutService, importLayoutColumns))
            {
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateIfColumnsPositionAreValid(string messageType,
                                                                   IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            var positions = importLayoutColumns.Select(x => x.Position);

            if (!positions.Any(x => x == 1))
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                    "There must be a column in position one."));
                return false;
            }

            var isConsecutive = !positions.Select((i, j) => i - j).Distinct().Skip(1).Any();
            if (!isConsecutive)
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                    "Columns are not in consecutive order."));
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateIfColumnNameRepeat(string messageType,
                                                            IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            if (importLayoutColumns.Count() != importLayoutColumns.GroupBy(x => x.Name).Count())
            {
                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                    "There are repeated columns."));
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateIfColumnNameExists(string messageType,
                                                            ImportLayoutService importLayoutService,
                                                            IEnumerable<ImportLayoutColumn> importLayoutColumns)
        {
            var properties = _importFieldRetriever.GetProperties(importLayoutService);

            foreach (var column in importLayoutColumns)
            {
                var columnWasFound = false;

                foreach (var property in properties)
                {
                    var customAttribute = property.GetCustomAttributes(typeof(ImportFieldAttribute), false).SingleOrDefault();
                    if (customAttribute != null)
                    {
                        var fieldAttribute = (ImportFieldAttribute)customAttribute;
                        if (fieldAttribute.Name == column.Name)
                        {
                            columnWasFound = true;
                            
                            if (property.PropertyType == typeof(DateTime) && string.IsNullOrEmpty(column.Format))
                            {
                                await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                                    $"Column name '{column.Name}' must have a format."));
                                return false;
                            }    

                            break;
                        }
                    }
                }

                if (!columnWasFound)
                {
                    await _mediatorHandler.PublishDomainNotification(new DomainNotification(messageType,
                        $"Column name '{column.Name}' not found in entity '{importLayoutService}'."));
                    return false;
                }
            }

            return true;
        }
    }
}
