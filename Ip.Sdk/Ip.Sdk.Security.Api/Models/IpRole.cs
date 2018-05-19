using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Security.Api.Models
{
    public class IpRole : IIpRole
    {
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName { get; set; }
    }
}