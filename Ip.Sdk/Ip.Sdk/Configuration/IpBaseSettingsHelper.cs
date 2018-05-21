using Ip.Sdk.Configuration.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ip.Sdk.Configuration
{
    /// <summary>
    /// Abstract base class for settings helpers
    /// </summary>
    public abstract class IpBaseSettingsHelper : IIpBaseSettingsHelper
    {
        /// <summary>
        /// Validates that the args have the required keys present
        /// </summary>
        /// <param name="args">The arguments to validate</param>
        /// <param name="requiredKeys">The required keys</param>
        public virtual IList<string> ValidateSettingsArgs(IList<IIpSettingArgument> args, IList<string> requiredKeys)
        {
            var exceptions = new List<string>();

            foreach (var rk in requiredKeys)
            {
                if (!args.Any(a => a.ArgumentKey.Equals(rk, System.StringComparison.OrdinalIgnoreCase)))
                {
                    exceptions.Add(string.Format("Required Key: {0} is missing from the settings arguments", rk));
                }
            }

            return exceptions;
        }

        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public abstract object GetSetting(IList<IIpSettingArgument> args);

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public abstract void SaveSetting(IList<IIpSettingArgument> args);

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public abstract void DeleteSetting(IList<IIpSettingArgument> args);
    }
}
