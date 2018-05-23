using Ip.Sdk.Configuration.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Ip.Sdk.Configuration
{
    /// <summary>
    /// Helper class for getting and saving settings to the configuration file
    /// </summary>
    internal class IpConfigurationSettingsHelper : IpBaseSettingsHelper, IIpConfigurationSettingsHelper
    {
        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public override object GetSetting(IList<IIpSettingArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args);

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var configSection = args.FirstOrDefault(a => a.ArgumentKey.Equals("configsection", StringComparison.OrdinalIgnoreCase));
            var settingId = args.FirstOrDefault(a => a.ArgumentKey.Equals("settingid", StringComparison.OrdinalIgnoreCase));

            if (configSection.ArgumentValue.Equals("appsettings", StringComparison.OrdinalIgnoreCase))
            {
                return GetSystemSetting(settingId.ArgumentValue);
            }
            
            if (configSection.ArgumentValue.Equals("connectionstrings", StringComparison.OrdinalIgnoreCase))
            {
                return GetConnectionString(settingId.ArgumentValue);
            }

            throw new IpSettingException(string.Format("Unable to find a Configuration for value: {0}", configSection.ArgumentValue));
        }

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public override void SaveSetting(IList<IIpSettingArgument> args)
        {
            throw new IpSettingException("The base manager does not allow editing of configuration settings at runtime, please extend the factory and create a new class to handle this");
        }

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public override void DeleteSetting(IList<IIpSettingArgument> args)
        {
            throw new IpSettingException("The base manager does not allow editing of configuration settings at runtime, please extend the factory and create a new class to handle this");
        }

        /// <summary>
        /// Gets system settings based on the name of the setting
        /// </summary>
        /// <param name="settingName">The name of the setting</param>
        /// <returns>A setting value of type T</returns>
        public string GetSystemSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }

        /// <summary>
        /// Gets a Connection String by its name from the config
        /// </summary>
        /// <param name="connectionStringName">The name of the connection string</param>
        /// <returns>A Connection String object from the config</returns>
        public ConnectionStringSettings GetConnectionString(string connectionStringName)
        {
            if (ConfigurationManager.ConnectionStrings[connectionStringName] != null)
            {
                return ConfigurationManager.ConnectionStrings[connectionStringName];
            }
            else
            {
                throw new IpSettingException(string.Format("Connection String: {0} not found in the ConnectionStrings", connectionStringName));
            }
        }
    }
}
