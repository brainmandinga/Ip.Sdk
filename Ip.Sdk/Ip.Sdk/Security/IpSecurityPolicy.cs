using Ip.Sdk.Security.Interfaces;
using Microsoft.Owin.Security.OAuth;

namespace Ip.Sdk.Security
{
    /// <summary>
    /// Delegate method for loading a security policy
    /// </summary>
    /// <param name="policy">The policy object to assign to</param>
    public delegate void LoadSecurityPolicy(IIpSecurityPolicy policy);

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
        /// <param name="policyLoader">Provide a policy loader delegate to load the security policy</param>
        public IpSecurityPolicy(LoadSecurityPolicy policyLoader = null)
        {
            policyLoader?.Invoke(this);
        }        
    }
}