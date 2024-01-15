﻿using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Supply.Application.Interfaces;
using Supply.Application.Services;
using Supply.Caching.Interfaces;
using Supply.Domain.CommandHandlers;
using Supply.Domain.Commands.VeiculoCommands;
using Supply.Domain.Commands.VeiculoMarcaCommands;
using Supply.Domain.Commands.VeiculoModeloCommands;
using Supply.Domain.Core.Mediator;
using Supply.Domain.Core.MessageBroker;
using Supply.Domain.Events.VeiculoEvents;
using Supply.Domain.Events.VeiculoMarcaEvents;
using Supply.Domain.Events.VeiculoModeloEvents;
using Supply.Domain.Interfaces;
using Supply.Infra.Data.Context;
using Supply.Infra.Data.EventHandlers;
using Supply.Infra.Data.Repositories.Cache;
using Supply.Infra.Data.Repositories.Data;

namespace Supply.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();
            services.AddScoped<IVeiculoMarcaAppService, VeiculoMarcaAppService>();
            services.AddScoped<IVeiculoModeloAppService, VeiculoModeloAppService>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain Bus (MessageBroker)
            services.AddScoped<IMessageBrokerBus, MessageBrokerBus>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();

            services.AddScoped<IRequestHandler<AddVeiculoMarcaCommand, ValidationResult>, VeiculoMarcaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateVeiculoMarcaCommand, ValidationResult>, VeiculoMarcaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVeiculoMarcaCommand, ValidationResult>, VeiculoMarcaCommandHandler>();

            services.AddScoped<IRequestHandler<AddVeiculoModeloCommand, ValidationResult>, VeiculoModeloCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateVeiculoModeloCommand, ValidationResult>, VeiculoModeloCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVeiculoModeloCommand, ValidationResult>, VeiculoModeloCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<VeiculoAddedEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoUpdatedEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoRemovedEvent>, VeiculoEventHandler>();

            services.AddScoped<INotificationHandler<VeiculoMarcaAddedEvent>, VeiculoMarcaEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoMarcaUpdatedEvent>, VeiculoMarcaEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoMarcaRemovedEvent>, VeiculoMarcaEventHandler>();

            services.AddScoped<INotificationHandler<VeiculoModeloAddedEvent>, VeiculoModeloEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoModeloUpdatedEvent>, VeiculoModeloEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoModeloRemovedEvent>, VeiculoModeloEventHandler>();

            // Infra - Data
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoMarcaRepository, VeiculoMarcaRepository>();
            services.AddScoped<IVeiculoModeloRepository, VeiculoModeloRepository>();

            services.AddScoped<IVeiculoCacheRepository, VeiculoCacheRepository>();
            services.AddScoped<IVeiculoMarcaCacheRepository, VeiculoMarcaCacheRepository>();
            services.AddScoped<IVeiculoModeloCacheRepository, VeiculoModeloCacheRepository>();

            services.AddScoped<SupplyDataContext>();
            services.AddScoped<SupplyCacheContext>();
        }
    }
}
