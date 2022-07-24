using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middlewares.ExceptionHandler
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ExceptionHandle(context, exception);
            }
        }

        private Task ExceptionHandle(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 400;

            Type exceptionType = exception.GetType();
            int statusCode = context.Response.StatusCode;
            string message = exception.Message;


            if (exceptionType == typeof(ValidationException))
            {
                var validationException = exception as ValidationException;
                return context.Response.WriteAsync(new ValidationExceptionDetail
                {
                    Type = exceptionType.Name,
                    Message = message,
                    StatusCode = statusCode,
                    Errors = validationException.Errors
                }.ToJson());
            }

            return context.Response.WriteAsync(new ExceptionDetail
            {
                Type = exceptionType.Name,
                Message = message,
                StatusCode = statusCode
            }.ToJson());
        }
    }
}
