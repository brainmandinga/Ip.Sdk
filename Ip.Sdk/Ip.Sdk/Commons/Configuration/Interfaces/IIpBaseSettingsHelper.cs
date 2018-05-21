using System.Collections.Generic;

namespace Ip.Sdk.Commons.Configuration.Interfaces
{
    /// <summary>
    /// Interface for a base settings helper
    /// </summary>
    public interface IIpBaseSettingsHelper
    {
        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        object GetSetting(string settingId, IList<IIpSettingArgument> args);

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="settingValue">The value of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        void SaveSetting(string settingId, object settingValue, IList<IIpSettingArgument> args);

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        void DeleteSetting(string settingId, IList<IIpSettingArgument> args);
    }
}
