using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;
        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    await _next(context);
                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                }
            }
        }
    }
}
