using Core.Utilities.ServiceProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceModules
{
    public class StaticServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            StaticServiceProvider.CreateInstance(services);
        }
    }
}
