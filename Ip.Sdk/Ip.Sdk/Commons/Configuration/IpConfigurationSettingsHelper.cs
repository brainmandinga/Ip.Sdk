using Ip.Sdk.Commons.Configuration.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Ip.Sdk.Commons.Configuration
{
    /// <summary>
    /// Helper class for getting and saving settings to the configuration file
    /// </summary>
    internal class IpConfigurationSettingsHelper : IIpConfigurationSettingsHelper
    {
        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public object GetSetting(string settingId, IList<IIpSettingArgument> args)
        {
            var configSection = args.FirstOrDefault(a => a.ArgumentKey.Equals("configsection", StringComparison.OrdinalIgnoreCase));

            #region Validations
            if (configSection == null)
            {
                throw new IpSettingException("Unable to find the ConfigSection Argument, to get the configuration");
            }
            #endregion

            if (configSection.ArgumentValue.Equals("appsettings", StringComparison.OrdinalIgnoreCase))
            {
                return GetSystemSetting(settingId);
            }
            
            if (configSection.ArgumentValue.Equals("connectionstrings", StringComparison.OrdinalIgnoreCase))
            {
                return GetConnectionString(settingId);
            }

            throw new IpSettingException(string.Format("Unable to find a Configuration for value: {0}", configSection.ArgumentValue));
        }

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="settingValue">The value of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        public void SaveSetting(string settingId, object settingValue, IList<IIpSettingArgument> args)
        {
            throw new IpSettingException("The base manager does not allow editing of configuration settings at runtime, please extend the factory and create a new class to handle this");
        }

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="settingId">The Id of the setting</param>
        /// <param name="args">A collection of arguments for the settings</param>
        public void DeleteSetting(string settingId, IList<IIpSettingArgument> args)
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
