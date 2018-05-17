namespace Ip.Sdk.Security.AuthObjects
{
    public class IpResponse<T>
    {
        /// <summary>
        /// A status enumeration
        /// </summary>
        public T Status { get; set; }

        /// <summary>
        /// The message for the response
        /// </summary>
        public string ResponseMessage { get; set; }
    }
}
