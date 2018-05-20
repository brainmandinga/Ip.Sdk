using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class IpDataAccessException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpDataAccessException()
            : base("An unknown error occured with the database access") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpDataAccessException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpDataAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
