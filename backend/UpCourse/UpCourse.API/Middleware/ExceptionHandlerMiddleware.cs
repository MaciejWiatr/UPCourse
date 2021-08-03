using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UpCourse.API.Exceptions;

namespace UpCourse.API.Middleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException exception)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new {message = "Not found"});
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new {message = "Bad request"});
            }
        }
    }
}