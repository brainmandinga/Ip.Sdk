using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    public class IpDataAccessParameterException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpDataAccessParameterException()
            : base("An unknown error occured with the database parameters") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpDataAccessParameterException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpDataAccessParameterException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
