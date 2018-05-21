using Ip.Sdk.Commons.Configuration.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Commons.Configuration
{
    /// <summary>
    /// Helper class for getting and saving settings to the database
    /// </summary>
    internal class IpDatabaseSettingsHelper : IIpDatabaseSettingsHelper
    {
        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public object GetSetting(IList<IIpSettingArgument> args)
        {
            return null;
        }

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public void SaveSetting(IList<IIpSettingArgument> args)
        {

        }

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public void DeleteSetting(IList<IIpSettingArgument> args)
        {

        }
    }
}
