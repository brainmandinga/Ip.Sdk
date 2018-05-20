using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Api.Models
{
    /// <summary>
    /// Role Object
    /// </summary>
    public class IpRole : IIpRole
    {
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName { get; set; }
    }
}