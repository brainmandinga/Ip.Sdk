using System.ComponentModel;

namespace Ip.Sdk.Commons.Enumerations
{
    /// <summary>
    /// Statuses for Password Edits
    /// </summary>
    public enum PasswordEditStatus
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
        /// Password was not complex enough
        /// </summary>
        [Description("Password does not meet requirements")]
        PasswordInvalid = 3,

        /// <summary>
        /// The password and confirm password don't match
        /// </summary>
        [Description("Password and confirm password do not match")]
        MismatchPassword = 4,

        /// <summary>
        /// The username wasn't provided
        /// </summary>
        [Description("Username was not provided")]
        MissingUsername = 5,

        /// <summary>
        /// The password was not provided
        /// </summary>
        [Description("Password was not provided")]
        PasswordMissing = 6,

        /// <summary>
        /// Confirm password was not provided
        /// </summary>
        [Description("Confirm password was not provided")]
        ConfirmPasswordMissing = 7,

        /// <summary>
        /// The user did not provide correct answers to one or more security questions
        /// </summary>
        [Description("Failed to correctly answer security questions")]
        SecurityQuestionFailed = 8,

        /// <summary>
        /// The security questions/answers are missing
        /// </summary>
        [Description("Security questions/answers missing")]
        SecurityQuestionsMissing = 9,

        /// <summary>
        /// Unknown failure reason
        /// </summary>
        [Description("Failed for other reasons")]
        Other = 0
    }
}
