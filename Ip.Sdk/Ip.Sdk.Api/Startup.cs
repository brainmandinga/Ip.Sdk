using Ip.Sdk.Api.Models;
using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.Commons.Configuration.Factories;
using Ip.Sdk.Commons.Configuration.Interfaces;
using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.Security.AuthObjects;
using Ip.Sdk.Security.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Web.Http;

[assembly: OwinStartup(typeof(Ip.Sdk.Api.Startup))]
namespace Ip.Sdk.Api
{
    /// <summary>
    /// Startup runs at application start
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the application
        /// </summary>
        /// <param name="app">The app</param>
        public void Configuration (IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var securityPolicy = new IpSecurityPolicy(LoadDefaultSecurityPolicy);

            ConfigureOAuth(app, securityPolicy);            
            WebApiConfig.Register(config);

            if (securityPolicy.AllowCors)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            }

            app.UseWebApi(config);
        }

        /// <summary>
        /// Configures the OAuth server 
        /// </summary>
        /// <param name="app">The app</param>
        /// <param name="securityPolicy">The Security Policy</param>
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

        /// <summary>
        /// Loads the default security policy
        /// </summary>
        private void LoadDefaultSecurityPolicy(IIpSecurityPolicy policy)
        {
            var helper = new IpSettingsFactory().GetSettingsHelper((IIpConfigurationSettingsHelper)null);

            var providerFullyQualifiedType = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("AuthProvider") }).ToString();

            try
            {
                var providerType = Type.GetType(providerFullyQualifiedType);
                policy.Provider = (OAuthAuthorizationServerProvider)Activator.CreateInstance(providerType);
            }
            catch
            {
                //load the default provider
                policy.Provider = new IpAuthorizationServerProvider();
            }

            //Load values from configuration
            policy.PasswordComplexityRegex = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("PasswordComplexityRegex") }).ToString();

            policy.AuthenticationEndpoint = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("AuthenticationEndpoint") }).ToString();

            policy.MinimumPasswordLength = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("MinimumPasswordLength") }).ChangeType<int>();

            policy.MaximumPasswordLength = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("MaximumPasswordLength") }).ChangeType<int>();

            policy.PasswordExpirationInDays = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("PasswordExpirationInDays") }).ChangeType<int>();

            policy.AuthTokenExpirationMinutes = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("AuthTokenExpirationMinutes") }).ChangeType<int>();

            policy.LockoutAttemptCount = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("LockoutAttemptCount") }).ChangeType<int>();

            policy.RequireRegistrationConfirmation = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("RequireRegistrationConfirmation") }).ToBool();

            policy.UseTwoFactorAuthentication = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("UseTwoFactorAuthentication") }).ToBool();

            policy.UseSecurityQuestions = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("UseSecurityQuestions") }).ToBool();

            policy.AllowInsecureHttp = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("AllowInsecureHttp") }).ToBool();

            policy.AllowCors = helper.GetSetting(new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg(),
                IpSettingArgument.GetStandardSettingIdArg("AllowCors") }).ToBool();
        }
    }
}