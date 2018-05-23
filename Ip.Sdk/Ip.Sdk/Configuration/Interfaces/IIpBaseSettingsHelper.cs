using Ip.Sdk.Commons.Arguments.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Configuration.Interfaces
{
    /// <summary>
    /// Interface for a base settings helper
    /// </summary>
    public interface IIpBaseSettingsHelper
    {
        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        object GetSetting(IList<IIpArgument> args);

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        void SaveSetting(IList<IIpArgument> args);

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        void DeleteSetting(IList<IIpArgument> args);
    }
}
