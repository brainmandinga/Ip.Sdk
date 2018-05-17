using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Ip.Sdk.Security.Api.Startup))]
namespace Ip.Sdk.Security.Api
{
    public class Startup
    {
        public void Configuration (IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);


        }
    }
}