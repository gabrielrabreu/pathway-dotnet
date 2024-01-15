using Haze.Authentication.Application.Interfaces;
using Haze.Authentication.Application.Services;
using Haze.Authentication.Domain.CommandHandlers;
using Haze.Authentication.Domain.Commands.UserCommands;
using Haze.Authentication.Domain.Repositories;
using Haze.Authentication.Infra.Data.Context;
using Haze.Authentication.Infra.Data.Repositories;
using Haze.Authentication.Web.JwtBearer;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Haze.Authentication.Infra
{
    public static class ServiceRegistrator
    {
        public static void RegisterAuthenticationServices(this IServiceCollection services)
        {
            // Auth
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtBearerSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IRequestHandler<AddUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();

            // Context
            services.AddDbContext<AuthenticationDataDbContext>();
        }
    }
}