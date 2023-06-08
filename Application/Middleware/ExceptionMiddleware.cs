using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Application.Middleware
{
    internal class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(BadValidationException exception)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
