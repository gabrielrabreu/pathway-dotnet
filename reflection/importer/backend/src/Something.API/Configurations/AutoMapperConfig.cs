using Something.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Something.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DtoToCommandMappingProfile),
                                   typeof(EntityToDtoMappingProfile));
        }
    }
}
