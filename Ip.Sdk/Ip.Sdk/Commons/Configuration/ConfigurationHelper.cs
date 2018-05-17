using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;
using System.Configuration;
using System.Linq;

namespace Ip.Sdk.Commons.Configuration
{
    public static class ConfigurationHelper
    {
        public static string GetSystemSetting(string settingName)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Any(k => k.Equals(settingName, StringComparison.OrdinalIgnoreCase)))
            {
                return ConfigurationManager.AppSettings[settingName];
            }
            else
            {
                throw new SystemSettingException(string.Format("Setting: {0} not found in the AppSettings", settingName));
            }
        }

        public static ConnectionStringSettings GetConnectionString(string connectionStringName)
        {
            if (ConfigurationManager.ConnectionStrings[connectionStringName] != null)
            {
                return ConfigurationManager.ConnectionStrings[connectionStringName];
            }
            else
            {
                throw new SystemSettingException(string.Format("Connection String: {0} not found in the ConnectionStrings", connectionStringName));
            }
        }
    }
}
