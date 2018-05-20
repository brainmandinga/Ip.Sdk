namespace Ip.Sdk.Security.AuthObjects
{
    /// <summary>
    /// Generic Response Object
    /// </summary>
    /// <typeparam name="T">An Enumeration for the Status</typeparam>
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
