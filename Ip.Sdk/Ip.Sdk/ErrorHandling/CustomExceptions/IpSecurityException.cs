using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class IpSecurityException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpSecurityException()
            : base("An unknown error occured with the security system") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpSecurityException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpSecurityException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
