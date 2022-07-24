using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptor
{
    public abstract class InterceptorAspect : Attribute, IInterceptor
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public virtual void Intercept(IInvocation invocation)
        {
            bool state = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                state = false;
                OnException(invocation, exception);
                throw exception;
            }
            finally
            {
                if (state)
                    OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}
