using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.Commons.Configuration.Factories;
using Ip.Sdk.Commons.Configuration.Interfaces;
using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.Security.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;

namespace Ip.Sdk.Api.Models
{
    /// <summary>
    /// Security policy object
    /// </summary>
    public class IpSecurityPolicy : IIpSecurityPolicy
    {
        /// <summary>
        /// The regular expression that handles matching of password complexity
        /// </summary>
        public string PasswordComplexityRegex { get; set; }

        /// <summary>
        /// The API Authentication Endpoint
        /// </summary>
        public string AuthenticationEndpoint { get; set; }

        /// <summary>
        /// The minimum password length
        /// </summary>
        public int MinimumPasswordLength { get; set; }

        /// <summary>
        /// The maximum password length
        /// </summary>
        public int MaximumPasswordLength { get; set; }

        /// <summary>
        /// How many days is a password allowed to be 
        /// </summary>
        public int PasswordExpirationInDays { get; set; }

        /// <summary>
        /// How many minutes before the AuthToken Expires
        /// </summary>
        public int AuthTokenExpirationMinutes { get; set; }

        /// <summary>
        /// The number of bad password attempts before lockout
        /// </summary>
        public int LockoutAttemptCount { get; set; }

        /// <summary>
        /// Should the user be required to confirm their registration?
        /// </summary>
        public bool RequireRegistrationConfirmation { get; set; }

        /// <summary>
        /// Should we use two-factor authentication
        /// </summary>
        public bool UseTwoFactorAuthentication { get; set; }

        /// <summary>
        /// Should the user use security questions/answers
        /// </summary>
        public bool UseSecurityQuestions { get; set; }

        /// <summary>
        /// Should the authentication allow plain http
        /// </summary>
        public bool AllowInsecureHttp { get; set; }

        /// <summary>
        /// Should the system allow CORS requests
        /// </summary>
        public bool AllowCors { get; set; }

        /// <summary>
        /// The OAuth authorization provide to use
        /// </summary>
        public OAuthAuthorizationServerProvider Provider { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loadDefault">Set this to true if you want to automatically load server defaults, leave blank otherwise</param>
        public IpSecurityPolicy(bool loadDefault = false)
        {
            if (loadDefault)
            {
                LoadDefaultSecurityPolicy();
            }
        }

        /// <summary>
        /// Loads the default security policy
        /// </summary>
        public virtual void LoadDefaultSecurityPolicy()
        {
            var configHelper = new IpSettingsFactory().GetSettingsHelper((IIpConfigurationSettingsHelper)null);
            var providerFullyQualifiedType = configHelper.GetSetting("AuthProvider", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToString();

            try
            {
                var providerType = Type.GetType(providerFullyQualifiedType);
                Provider = (OAuthAuthorizationServerProvider)Activator.CreateInstance(providerType);
            }
            catch
            {
                //load the default provider
                Provider = new IpAuthorizationServerProvider();
            }

            //Load values from configuration
            PasswordComplexityRegex = configHelper.GetSetting("PasswordComplexityRegex", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToString();
            AuthenticationEndpoint = configHelper.GetSetting("AuthenticationEndpoint", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToString();
            MinimumPasswordLength = configHelper.GetSetting("MinimumPasswordLength", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ChangeType<int>();
            MaximumPasswordLength = configHelper.GetSetting("MaximumPasswordLength", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ChangeType<int>();
            PasswordExpirationInDays = configHelper.GetSetting("PasswordExpirationInDays", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ChangeType<int>();
            AuthTokenExpirationMinutes = configHelper.GetSetting("AuthTokenExpirationMinutes", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ChangeType<int>();
            LockoutAttemptCount = configHelper.GetSetting("LockoutAttemptCount", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ChangeType<int>();
            RequireRegistrationConfirmation = configHelper.GetSetting("RequireRegistrationConfirmation", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToBool();
            UseTwoFactorAuthentication = configHelper.GetSetting("UseTwoFactorAuthentication", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToBool();
            UseSecurityQuestions = configHelper.GetSetting("UseSecurityQuestions", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToBool();
            AllowInsecureHttp = configHelper.GetSetting("AllowInsecureHttp", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToBool();
            AllowCors = configHelper.GetSetting("AllowCors", new List<IIpSettingArgument> { IpSettingArgument.GetStandardAppSettingArg() }).ToBool();
        }
    }
}