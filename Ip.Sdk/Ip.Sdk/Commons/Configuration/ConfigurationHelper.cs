using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System.Configuration;

namespace Ip.Sdk.Commons.Configuration
{
    /// <summary>
    /// Configuration Helper class
    /// </summary>
    public static class ConfigurationHelper
    {
        //TODO: Build a factory and abstraction around the configuration elements to allow one to configure and get settings from multiple sources. web/app.config, file system, database, and code
        //TODO: Make extensible so more could be added

        /// <summary>
        /// Gets system settings based on the name of the setting
        /// </summary>
        /// <typeparam name="T">The Type that should be returned</typeparam>
        /// <param name="settingName">The name of the setting</param>
        /// <returns>A setting value of type T</returns>
        public static T GetSystemSetting<T>(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName].ChangeType<T>();
        }

        /// <summary>
        /// Gets a Connection String by its name from the config
        /// </summary>
        /// <param name="connectionStringName">The name of the connection string</param>
        /// <returns>A Connection String object from the config</returns>
        public static ConnectionStringSettings GetConnectionString(string connectionStringName)
        {
            if (ConfigurationManager.ConnectionStrings[connectionStringName] != null)
            {
                return ConfigurationManager.ConnectionStrings[connectionStringName];
            }
            else
            {
                throw new IpSystemSettingException(string.Format("Connection String: {0} not found in the ConnectionStrings", connectionStringName));
            }
        }
    }
}
