namespace Ip.Sdk.Security.Interfaces
{
    public interface IIpSecurityPolicy
    {
        /// <summary>
        /// The regular expression that handles matching of password complexity
        /// </summary>
        string PasswordComplexityRegex { get; set; }

        /// <summary>
        /// How many days is a password allowed to be 
        /// </summary>
        int PasswordExpirationInDays { get; set; }

        /// <summary>
        /// How many minutes before the AuthToken Expires
        /// </summary>
        int AuthTokenExpirationMinutes { get; set; }

        /// <summary>
        /// The number of bad password attempts before lockout
        /// </summary>
        int LockoutAttemptCount { get; set; }

        /// <summary>
        /// Should the user be required to confirm their registration?
        /// </summary>
        bool RequireRegistrationConfirmation { get; set; }

        /// <summary>
        /// Should we use two-factor authentication
        /// </summary>
        bool UseTwoFactorAuthentication { get; set; }        

        /// <summary>
        /// Should the user use security questions/answers
        /// </summary>
        bool UseSecurityQuestions { get; set; }
    }
}
