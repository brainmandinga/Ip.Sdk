using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class IpDataExtensionException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpDataExtensionException()
            : base("An unknown error occured with the data extension") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpDataExtensionException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpDataExtensionException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
