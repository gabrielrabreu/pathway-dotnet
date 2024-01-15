using DIMI.WebApi.Services;
using DIMI.WebApi.Services.Interfaces;

namespace DIMI.WebApi.Scope.Extensions
{
    public static class DIServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Transient objects are always different; a new instance is provided to every controller and every service.
            services.AddTransient<ITransientService, TransientService>();

            // Scoped objects are the same within a request, but different across different requests.
            services.AddScoped<IScopedService, ScopedService>();

            // Singleton objects are the same for every object and every request.
            services.AddSingleton<ISingletonService, SingletonService>();
        }
    }

}
