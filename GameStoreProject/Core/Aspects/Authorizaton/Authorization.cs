using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using Core.Utilities.ServiceProvider;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Authorizaton
{
    public class Authorization:InterceptorAspect
    {
        private readonly string[] _roleClaims;
        private readonly IHttpContextAccessor _httpClientAccessor;
        public Authorization(params string[] rolClaims)
        {
            _roleClaims=rolClaims;
            _httpClientAccessor=StaticServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            
        }
    }
}
