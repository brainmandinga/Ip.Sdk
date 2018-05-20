﻿using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.Security.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System;

namespace Ip.Sdk.Api.Models
{
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
            //TODO: When the Configuration Helper has been refactored to be more abstract, this will need to change.
            var providerFullyQualifiedType = ConfigurationHelper.GetSystemSetting<string>("AuthProvider");

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
            PasswordComplexityRegex = ConfigurationHelper.GetSystemSetting<string>("PasswordComplexityRegex");
            AuthenticationEndpoint = ConfigurationHelper.GetSystemSetting<string>("AuthenticationEndpoint");
            MinimumPasswordLength = ConfigurationHelper.GetSystemSetting<int>("MinimumPasswordLength");
            MaximumPasswordLength = ConfigurationHelper.GetSystemSetting<int>("MaximumPasswordLength");
            PasswordExpirationInDays = ConfigurationHelper.GetSystemSetting<int>("PasswordExpirationInDays");
            AuthTokenExpirationMinutes = ConfigurationHelper.GetSystemSetting<int>("AuthTokenExpirationMinutes");
            LockoutAttemptCount = ConfigurationHelper.GetSystemSetting<int>("LockoutAttemptCount");
            RequireRegistrationConfirmation = ConfigurationHelper.GetSystemSetting<bool>("RequireRegistrationConfirmation");
            UseTwoFactorAuthentication = ConfigurationHelper.GetSystemSetting<bool>("UseTwoFactorAuthentication");
            UseSecurityQuestions = ConfigurationHelper.GetSystemSetting<bool>("UseSecurityQuestions");
            AllowInsecureHttp = ConfigurationHelper.GetSystemSetting<bool>("AllowInsecureHttp");
            AllowCors = ConfigurationHelper.GetSystemSetting<bool>("AllowCors");
        }
    }
}