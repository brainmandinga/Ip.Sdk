using System.ComponentModel;

namespace Ip.Sdk.Api.Enumerations
{
    /// <summary>
    /// User Edit status 
    /// </summary>
    public enum IpUserEditStatus
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
        /// Email address was not correct
        /// </summary>
        [Description("Email format was incorrect or invalid")]
        EmailInvalid = 3,

        /// <summary>
        /// Password was not complex enough
        /// </summary>
        [Description("Password does not meet requirements")]
        PasswordInvalid = 4,

        /// <summary>
        /// The username wasn't provided
        /// </summary>
        [Description("Username was not provided")]
        MissingUsername = 5,

        /// <summary>
        /// The email address wasn't provided
        /// </summary>
        [Description("Email address was not provided")]
        MissingEmail = 6,

        /// <summary>
        /// Username is already being used
        /// </summary>
        [Description("Username is already in use")]
        UsernameInUse = 7,

        /// <summary>
        /// The email address is already being used
        /// </summary>
        [Description("Email address is already in use")]
        EmailInUse = 8,

        /// <summary>
        /// Unknown failure reason
        /// </summary>
        [Description("Failed for other reasons")]
        Other = 0
    }
}
