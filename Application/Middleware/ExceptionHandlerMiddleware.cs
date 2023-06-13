using Application.Interfaces;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Application.Middleware
{
    internal class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILoggingHandler _loggingHandler;

        public ExceptionHandlerMiddleware(ILoggingHandler loggingHandler)
        {
            _loggingHandler = loggingHandler;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadValidationException exception)
            {
                _loggingHandler.LogException(exception);

                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
