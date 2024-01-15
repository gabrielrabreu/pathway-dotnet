using Core.Domain.Mediator;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Something.Application.Common;
using Something.Application.Interfaces;
using Something.Application.Services;
using Something.Domain.CommandHandlers;
using Something.Domain.Commands.ImportCommands;
using Something.Domain.Commands.ImportLayoutCommands;
using Something.Domain.Commands.XptoCommands;
using Something.Domain.Common;
using Something.Domain.Events.ImportEvents;
using Something.Domain.Interfaces;
using Something.Infra.Data.Contexts;
using Something.Infra.Data.Repositories;

namespace Something.Infra.CrossCutting.IoC
{

    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - ImportFieldRetriever
            services.AddScoped<IImportFieldRetriever, ImportFieldRetriever>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddXptoCommand, Unit>, XptoCommandHandler>();
            services.AddScoped<IRequestHandler<AddImportLayoutCommand, Unit>, ImportLayoutCommandHandler>();
            services.AddScoped<IRequestHandler<AddImportCommand, Unit>, ImportCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ImportAddedEvent>, ImportAppService>();

            // Infra Data - Contexts
            services.AddScoped<DataContext>();

            // Infra Data - Repositories
            services.AddScoped<IXptoRepository, XptoRepository>();
            services.AddScoped<IImportLayoutRepository, ImportLayoutRepository>();
            services.AddScoped<IImportRepository, ImportRepository>();

            // Application - AppServices
            services.AddScoped<IXptoAppService, XptoAppService>();
            services.AddScoped<IImportLayoutAppService, ImportLayoutAppService>();
            services.AddScoped<IImportAppService, ImportAppService>();

        }
    }
}
