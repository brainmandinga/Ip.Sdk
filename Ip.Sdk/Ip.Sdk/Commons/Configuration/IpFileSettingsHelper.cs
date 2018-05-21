using Ip.Sdk.Commons.Configuration.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Commons.Configuration
{
    /// <summary>
    /// Helper class for getting and saving settings to the file system
    /// </summary>
    internal class IpFileSettingsHelper : IIpFileSettingsHelper
    {
        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public object GetSetting(string settingId, IList<IIpSettingArgument> args)
        {
            return null;
        }

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="settingValue">The value of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        public void SaveSetting(string settingId, object settingValue, IList<IIpSettingArgument> args)
        {

        }

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        public void DeleteSetting(string settingId, IList<IIpSettingArgument> args)
        {

        }
    }
}
