using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    public abstract class IpBaseException : Exception
    {
        //TODO: Implement common error handling funcionality here like logging

        protected IpBaseException(string message)
            : base(message) { }

        protected IpBaseException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
