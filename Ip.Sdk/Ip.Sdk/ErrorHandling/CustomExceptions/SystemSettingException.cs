using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    public class SystemSettingException : Exception
    {
        public SystemSettingException()
            : base("An unknown error occured with the system settings") { }

        public SystemSettingException(string message)
            : base(message) { }
    }
}
