using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceModules
{
    public class MeArchitectureServiceModule : IServiceModule
    {
        private readonly IConfiguration Configuration;
        public MeArchitectureServiceModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Load(IServiceCollection services)
        {
            
        }
    }
}
