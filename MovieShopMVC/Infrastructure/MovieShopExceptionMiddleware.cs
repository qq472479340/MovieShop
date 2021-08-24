using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.File;
using System.Security.Claims;

namespace MovieShopMVC.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Exception Middleware Begining");

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catching the exception in Middleware {ex}");
                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            switch (ex)
            {
                case ConflictException _:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case NotFoundException _:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var url = httpContext.Request.Path.Value;
            var controllerName = url.Split("/")[1];
            var actionName = url.Split("/")[2];
            var time = DateTime.Now;
            var stackTrace = ex.StackTrace;
            var errorMsg = ex.Message;
            string userId = null;
            //string type;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                userId = httpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            }

            var log = new LoggerConfiguration().WriteTo.File("ErrorInformation.txt", rollingInterval: RollingInterval.Day).CreateLogger();

            var logMsg = "\n" + "url: " + "\n\t" + url + "\n" + "Controller: " + "\n\t" + controllerName + "\n" + 
                "Action: " + "\n\t" + actionName + "\n" + "DateTime: " + "\n\t" + time + "\n" +
                "StackTrace: " + "\n" + stackTrace + "\n" + "ErrorMsg: " + "\n\t" + errorMsg;
            if(userId != null)
            {
                logMsg += "\n" + "userId: " + "\n\t" + userId;
            }
            log.Information(logMsg);

            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
