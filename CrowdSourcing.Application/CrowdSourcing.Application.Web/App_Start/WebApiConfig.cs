using CrowdSourcing.Application.Web.GlobalExeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace CrowdSourcing.Application.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


#if DEBUG
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler(true));
#else
            
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExeptionHandler(false));
#endif

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
