using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class IpSystemSettingException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpSystemSettingException()
            : base("An unknown error occured with the system settings") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpSystemSettingException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpSystemSettingException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
