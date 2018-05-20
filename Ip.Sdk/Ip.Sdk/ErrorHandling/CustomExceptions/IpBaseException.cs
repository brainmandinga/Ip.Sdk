using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Base Exception for custom exceptions
    /// </summary>
    public abstract class IpBaseException : Exception
    {
        //TODO: Implement common error handling funcionality here like logging

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        protected IpBaseException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        protected IpBaseException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
