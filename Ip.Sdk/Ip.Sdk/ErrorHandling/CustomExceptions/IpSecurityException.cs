using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    public class IpSecurityException : Exception
    {
        public IpSecurityException()
            : base("An unknown error occured with the security system") { }

        public IpSecurityException(string message)
            : base(message) { }

        public IpSecurityException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
