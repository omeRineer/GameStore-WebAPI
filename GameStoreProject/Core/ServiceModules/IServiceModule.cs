using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceModules
{
    public interface IServiceModule
    {
        void Load(IServiceCollection services);
    }
}
