using Ip.Sdk.Commons.Configuration.Interfaces;

namespace Ip.Sdk.Commons.Configuration.Factories
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
        /// <returns>A Database Settings Helper</returns>
        public IIpBaseSettingsHelper GetSettingsHelper(IIpDatabaseSettingsHelper helper)
        {
            return helper ?? new IpDatabaseSettingsHelper();
        }

        /// <summary>
        /// Gets a File Helper class
        /// </summary>
        /// <param name="helper">An optionally injectible helper object</param>
        /// <returns>A File Settings Helper</returns>
        public IIpBaseSettingsHelper GetSettingsHelper(IIpFileSettingsHelper helper)
        {
            return helper ?? new IpFileSettingsHelper();
        }
    }
}
