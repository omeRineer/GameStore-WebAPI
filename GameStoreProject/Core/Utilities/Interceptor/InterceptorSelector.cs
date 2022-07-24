using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptor
{
    public class InterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var methodInterceptors = type.GetMethod(method.Name).GetCustomAttributes<InterceptorAspect>().ToList();
            var classInterceptors = type.GetCustomAttributes<InterceptorAspect>().ToList();
            classInterceptors.AddRange(methodInterceptors);

            classInterceptors.AddRange(new List<InterceptorAspect>
            {

            });

            return classInterceptors.ToArray();
        }
    }
}
