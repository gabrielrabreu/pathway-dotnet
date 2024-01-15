using Authentication.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infra.CrossCutting.IoC
{
    public static class DependencyInjector
    {
        public static void Register(this IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<AuthenticationContext>();
        }
    }
}
