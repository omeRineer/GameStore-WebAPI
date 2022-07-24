using Core.Middlewares;
using Core.Middlewares.ExceptionHandler;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseCustomTransaction(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TransactionMiddleware>();
        }
    }
}
