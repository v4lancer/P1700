using FE_P1700.DTOs;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using FE_P1700.Models;

namespace FE_P1700.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;
        private IOptions<P1700ApiSettingsDto> _options;


        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env, IOptions<P1700ApiSettingsDto> options)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
            _options = options;
        }

        

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Obtener el controlador y el endpoint actual
                var nombreControlador = GetControllerName(context);
                var nombreEndPoint = GetActionName(context);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                var response = env.IsDevelopment() ? new ErrorLogDto(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString(), nombreControlador, nombreEndPoint) :
                new ErrorLogDto(context.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);


                await context.Response.WriteAsync(json);

            }

        }


        /// <summary>
        /// Obtener Controlador
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetControllerName(HttpContext context)
        {
            var routeData = context.GetRouteData();
            var controllerName = routeData.Values["controller"]?.ToString();
            return controllerName ?? "Unknown";
        }

        /// <summary>
        /// Obtener Endpoint
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetActionName(HttpContext context)
        {
            var routeData = context.GetRouteData();
            var actionName = routeData.Values["action"]?.ToString();
            return actionName ?? "Unknown";
        }

    }
}
