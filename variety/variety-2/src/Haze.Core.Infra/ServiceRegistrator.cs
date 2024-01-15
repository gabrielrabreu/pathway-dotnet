using Haze.Core.Domain.Mediator;
using Haze.Core.Domain.Notifications;
using Haze.Core.Infra.Data.Accessor;
using Haze.Core.Infra.Data.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Haze.Core.Infra
{
    public static class ServiceRegistrator
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            // Accessor
            services.AddScoped<ITenantAccessor, HttpContextInfoAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IDatabaseSettingsProvider>(new DatabaseSettingsProvider(Config.DatabaseSettings));

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}