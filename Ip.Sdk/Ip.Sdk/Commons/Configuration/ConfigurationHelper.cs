using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System.Configuration;

namespace Ip.Sdk.Commons.Configuration
{
    public static class ConfigurationHelper
    {
        //TODO: Build a factory and abstraction around the configuration elements to allow one to configure and get settings from multiple sources. web/app.config, file system, database, and code
        //TODO: Make extensible so more could be added

        public static T GetSystemSetting<T>(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName].ChangeType<T>();
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
