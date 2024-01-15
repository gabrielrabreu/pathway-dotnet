using AutoMapper;
using Haze.Anything.Application.Interfaces;
using Haze.Anything.Application.Services;
using Haze.Anything.Caching.CacheRepositories;
using Haze.Anything.Caching.Interfaces;
using Haze.Anything.Caching.Queries;
using Haze.Anything.Domain.CommandHandlers;
using Haze.Anything.Domain.Commands.FulanoCommands;
using Haze.Anything.Domain.Events.FulanoEvents;
using Haze.Anything.Domain.Repositories;
using Haze.Anything.Infra.AutoMapper;
using Haze.Anything.Infra.Data.Caching.CacheRepositories;
using Haze.Anything.Infra.Data.Caching.EventHandlers;
using Haze.Anything.Infra.Data.Context;
using Haze.Anything.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Haze.Anything.Infra
{
    public static class ServiceRegistrator
    {
        public static void RegisterAnythingServices(this IServiceCollection services)
        {
            // Fulano
            services.AddScoped<IFulanoRepository, FulanoRepository>();
            services.AddScoped<IFulanoAppService, FulanoAppService>();
            services.AddScoped<IFulanoCacheRepository, FulanoCacheRepository>();
            services.AddScoped<IFulanoQuery, FulanoQuery>();

            services.AddScoped<IRequestHandler<AddFulanoCommand, bool>, FulanoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFulanoCommand, bool>, FulanoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveFulanoCommand, bool>, FulanoCommandHandler>();

            services.AddScoped<INotificationHandler<FulanoAddedEvent>, FulanoEventHandler>();
            services.AddScoped<INotificationHandler<FulanoUpdatedEvent>, FulanoEventHandler>();
            services.AddScoped<INotificationHandler<FulanoRemovedEvent>, FulanoEventHandler>();

            // Context
            services.AddDbContext<AnythingDataDbContext>();
            services.AddDbContext<AnythingCacheDbContext>();
        }
    }
}