using Ip.Sdk.Commons.Enumerations;

namespace Ip.Sdk.Security.AuthObjects
{
    /// <summary>
    /// The response object useed for Authentication calls
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// The status of the authentication attempt
        /// </summary>
        public AuthenticationStatus Status { get; set; }

        /// <summary>
        /// The response message
        /// </summary>
        public string ResponseMessage { get; set; }
    }
}
