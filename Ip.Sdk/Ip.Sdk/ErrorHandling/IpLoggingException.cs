using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;

namespace Ip.Sdk.ErrorHandling
{
    /// <summary>
    /// Custom exception for logging
    /// </summary>
    public class IpLoggingException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpLoggingException()
            : base("An unknown error occured with the system settings") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpLoggingException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpLoggingException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
