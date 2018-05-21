using Ip.Sdk.Configuration.Interfaces;
using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;

namespace Ip.Sdk.Configuration.Factories
{
    /// <summary>
    /// A factory for getting settings classes
    /// </summary>
    public class IpSettingsFactory
    {
        /// <summary>
        /// Gets a Configuration Helper class
        /// </summary>
        /// <param name="helper">An optionally injectible helper object</param>
        /// <returns>A Configuration Settings Helper</returns>
        public IIpBaseSettingsHelper GetSettingsHelper(IIpConfigurationSettingsHelper helper)
        {
            return helper ?? new IpConfigurationSettingsHelper();
        }

        /// <summary>
        /// Gets a Database Helper class
        /// </summary>
        /// <param name="helper">An optionally injectible helper object</param>
        /// <param name="dataLayer">The Data Layer to Use</param>
        /// <returns>A Database Settings Helper</returns>
        public IIpBaseSettingsHelper GetSettingsHelper(IIpDatabaseSettingsHelper helper, IIpBaseDataLayer dataLayer)
        {
            return helper ?? new IpDatabaseSettingsHelper(dataLayer);
        }
    }
}
