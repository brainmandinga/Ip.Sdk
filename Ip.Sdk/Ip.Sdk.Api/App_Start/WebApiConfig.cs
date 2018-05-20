using System.Web.Http;

namespace Ip.Sdk.Api
{
    /// <summary>
    /// Configuration for the web api
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the web api
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
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
