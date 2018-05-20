using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Api.Models
{
    public class IpAuth : IIpAuth
    {
        /// <summary>
        /// The username to authenticate
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password to authenticate
        /// </summary>
        public string Password { get; set; }
    }
}