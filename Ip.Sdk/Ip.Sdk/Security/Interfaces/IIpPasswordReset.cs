using System.Collections.Generic;

namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// Password reset model
    /// </summary>
    public interface IIpPasswordReset
    {
        /// <summary>
        /// The password for creation
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// The confirm password for creation
        /// </summary>
        string ConfirmPassword { get; set; }

        /// <summary>
        /// A collection of security questions/answers
        /// </summary>
        IList<IIpSecurityQuestion> SecurityQuestions { get; set; }
    }
}
