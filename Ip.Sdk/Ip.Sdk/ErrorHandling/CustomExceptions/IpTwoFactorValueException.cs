using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    public class IpTwoFactorValueException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpTwoFactorValueException()
            : base("Two Factor Destination Value Invalid") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpTwoFactorValueException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpTwoFactorValueException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
