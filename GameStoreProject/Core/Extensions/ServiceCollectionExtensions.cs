using Core.ServiceModules;
using Core.Utilities.ServiceProvider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceModules(this IServiceCollection services, IServiceModule[] serviceModules)
        {
            if (serviceModules.Count() != 0)
            {
                foreach (var serviceModule in serviceModules)
                {
                    serviceModule.Load(services);
                }
            }

            StaticServiceProvider.CreateInstance(services);
            return services;

        }
    }
}
