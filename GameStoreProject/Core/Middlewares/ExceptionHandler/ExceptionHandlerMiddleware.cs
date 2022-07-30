using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
            int statusCode=context.Response.StatusCode = 400;

            var exceptionDetail = GetDetail(exception, statusCode).ToJson();
            return context.Response.WriteAsync(exceptionDetail);

        }

        private ExceptionDetail GetDetail(Exception exception, int statusCode)
        {
            string exceptionType = exception.GetType().Name;
            string message = exception.Message;

            switch (exception)
            {
                case ValidationException validationException:
                    return new ValidationExceptionDetail
                    {
                        Type = exceptionType,
                        StatusCode = statusCode,
                        Message = message,
                        Errors = validationException.Errors
                    };

                default:
                    return new ExceptionDetail
                    {
                        Type = exceptionType,
                        StatusCode = statusCode,
                        Message = message
                    };
            }
        }
    }
}
