using AutoMapper;
using Haze.Anything.Infra;
using Haze.Anything.Infra.AutoMapper;
using Haze.API.Setup.Swagger;
using Haze.Authentication.Infra;
using Haze.Authentication.Infra.AutoMapper;
using Haze.Core.Infra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Haze.API.Setup
{
    public static class ServiceRegistrator
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Dependencies from other contexts
            services.RegisterCoreServices();
            services.RegisterAuthenticationServices();
            services.RegisterAnythingServices();

            // AutoMapper
            services.AddAutoMapper(typeof(AnythingMappingProfile), typeof(AuthMappingProfile));

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<TenantOperationFilter>();
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Haze",
                        Version = "v1",
                        Description = "Haze - Base de projetos para .Net"
                    }
                );

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthenticationOperationFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
