﻿using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class IpDatabaseTypeException : IpBaseException
    {
        /// <summary>
        /// Custom exception
        /// </summary>
        public IpDatabaseTypeException()
            : base("An unknown error occured with the database types") { }

        /// <summary>
        /// Custom exception with custom message
        /// </summary>
        /// <param name="message">The Custom Message</param>
        public IpDatabaseTypeException(string message)
            : base(message) { }

        /// <summary>
        /// Custom exception with custom message and inner exception
        /// </summary>
        /// <param name="message">The Custom Message</param>
        /// <param name="innerException">The Inner Exception</param>
        public IpDatabaseTypeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
