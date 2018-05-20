using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class IpDataLayerException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpDataLayerException()
            : base("An unknown error occured with the data layer") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpDataLayerException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpDataLayerException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
