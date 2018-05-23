using System.ComponentModel;

namespace Ip.Sdk.Api.Enumerations
{
    /// <summary>
    /// An Enumeration for Authentication Status
    /// </summary>
    public enum IpAuthenticationStatus
    {
        /// <summary>
        /// Successful authentication
        /// </summary>
        [Description("Success")]
        Success = 1,

        /// <summary>
        /// User Not Found
        /// </summary>
        [Description("User not found")]
        UserNotFound = 2,

        /// <summary>
        /// Inactive user
        /// </summary>
        [Description("User not active")]
        UserNotActive = 3,

        /// <summary>
        /// User is not confirmed
        /// </summary>
        [Description("User not confirmed")]
        UserNotConfirmed = 4,

        /// <summary>
        /// User is locked out
        /// </summary>
        [Description("User locked out")]
        UserLockedOut = 5,

        /// <summary>
        /// Two factor authentication failure
        /// </summary>
        [Description("Two factor failure")]
        TwoFactorFailed = 6,

        /// <summary>
        /// The user was not authorized
        /// </summary>
        [Description("User not authorized")]
        NotAuthorized = 7,

        /// <summary>
        /// Unknown failure reason
        /// </summary>
        [Description("Failed for other reasons")]
        Other = 0
    }
}
