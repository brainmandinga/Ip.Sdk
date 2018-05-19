using Ip.Sdk.Security.Api.Models;
using Ip.Sdk.Security.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Ip.Sdk.Security.Api.Startup))]
namespace Ip.Sdk.Security.Api
{
    public class Startup
    {
        public void Configuration (IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var securityPolicy = new IpSecurityPolicy(true);

            ConfigureOAuth(app, securityPolicy);            
            WebApiConfig.Register(config);

            if (securityPolicy.AllowCors)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            }

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IIpSecurityPolicy securityPolicy)
        {        
            var serverOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = securityPolicy.AllowInsecureHttp,
                TokenEndpointPath = new PathString(securityPolicy.AuthenticationEndpoint),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(securityPolicy.AuthTokenExpirationMinutes),
                Provider = securityPolicy.Provider
            };

            app.UseOAuthAuthorizationServer(serverOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}