﻿using Autho.Application.Queries;
using Autho.Application.Queries.Integrations;
using Autho.Application.Queries.Integrations.Interfaces;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Services;
using Autho.Application.Services.Integration;
using Autho.Application.Services.Integration.Interfaces;
using Autho.Application.Services.Interfaces;
using Autho.Core.Providers;
using Autho.Core.Providers.Interfaces;
using Autho.Domain.Core.MediatorHandler;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Repositories;
using Autho.Domain.Repositories.Integration;
using Autho.Domain.Session;
using Autho.Domain.Session.Interfaces;
using Autho.Domain.Validations;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using Autho.Infra.CrossCutting.Integration;
using Autho.Infra.Data.Adapters;
using Autho.Infra.Data.Adapters.Integration;
using Autho.Infra.Data.Adapters.Integration.Interfaces;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Repositories;
using Autho.Infra.Data.Repositories.Integration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void Load(IServiceCollection services)
        {
            // Application - AppServices
            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IIntegrationAppService, IntegrationAppService>();

            // Application - AppQueries
            services.AddScoped<IProfileAppQuery, ProfileAppQuery>();
            services.AddScoped<IPermissionAppQuery, PermissionAppQuery>();
            services.AddScoped<IUserAppQuery, UserAppQuery>();
            services.AddScoped<IIntegrationAppQuery, IntegrationAppQuery>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<ITokenAppService, TokenAppService>();
            services.AddScoped<IHealthAppService, HealthAppService>();

            // Domain - Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Validations
            services.AddScoped<IProfileValidation, ProfileValidation>();
            services.AddScoped<IUserValidation, UserValidation>();

            // Infra - CrossCutting - Globalization
            services.AddScoped<IGlobalizationService, GlobalizationService>();

            // Infra - CrossCutting - Integration
            IntegrationBootStrapper.Load(services);

            // Infra - Data - Adapters
            services.AddScoped<IPermissionDataAdapter, PermissionDataAdapter>();
            services.AddScoped<IProfileDataAdapter, ProfileDataAdapter>();
            services.AddScoped<IUserDataAdapter, UserDataAdapter>();
            services.AddScoped<IIntegrationDataAdapter, IntegrationDataAdapter>();
            services.AddScoped<IIntegrationUserDataAdapter, IntegrationUserDataAdapter>();

            // Infra - Data - Contexts
            services.AddScoped<IAuthoContext, AuthoContext>();
            services.AddScoped<IBaseContext, AuthoContext>();
            services.AddScoped<AuthoContext>();

            // Infra - Data - Repositories
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIntegrationRepository, IntegrationRepository>();

            // Providers
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<ISessionAccessor, SessionAccessor>();
        }
    }
}
