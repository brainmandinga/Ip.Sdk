using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Security.AuthObjects
{
    /// <summary>
    /// Generic Response Object
    /// </summary>
    public class IpResponse : IIpResponse
    {
        /// <summary>
        /// A status enumeration
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// The message for the response
        /// </summary>
        public string ResponseMessage { get; set; }
    }
}
