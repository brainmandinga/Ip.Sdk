﻿using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Api.Models
{
    /// <summary>
    /// Claim object
    /// </summary>
    public class IpClaim : IIpClaim
    {
        /// <summary>
        /// The claim's key
        /// </summary>
        public string ClaimKey { get; set; }

        /// <summary>
        /// The claim's value
        /// </summary>
        public string ClaimValue { get; set; }
    }
}