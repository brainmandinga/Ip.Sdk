using Ip.Sdk.Security.AuthObjects;
using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Security.Factories
{
    /// <summary>
    /// Builds two factor authentication types
    /// </summary>
    public class IpTwoFactorFactory
    {
        /// <summary>
        /// Gets an Email Two Factor Destination
        /// </summary>
        /// <param name="destination">An optional destination object</param>
        /// <returns>An Email Two Factor Destination</returns>
        public IIpBaseTwoFactorDestination GetTwoFactorDestination(IIpEmailTwoFactorDestination destination)
        {
            return destination ?? new IpEmailTwoFactorDestination();
        }

        /// <summary>
        /// Gets an SMS Two Factor Destination
        /// </summary>
        /// <param name="destination">An optional destination object</param>
        /// <returns>An SMS Two Factor Destination</returns>
        public IIpBaseTwoFactorDestination GetTwoFactorDestination(IIpSmsTwoFactorDestination destination)
        {
            return destination ?? new IpSmsTwoFactorDestination();
        }

        /// <summary>
        /// Gets a Telephone Two Factor Destination
        /// </summary>
        /// <param name="destination">An optional destination object</param>
        /// <returns>A Telelphone Two Factor Destination</returns>
        public IIpBaseTwoFactorDestination GetTwoFactorDestination(IIpTelephoneTwoFactorDestination destination)
        {
            return destination ?? new IpTelephoneTwoFactorDestination();
        }
    }
}
