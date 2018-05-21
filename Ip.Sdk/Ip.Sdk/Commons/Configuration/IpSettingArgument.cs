using Ip.Sdk.Commons.Configuration.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Commons.Configuration
{
    /// <summary>
    /// Class for a setting argument for crud operations
    /// </summary>
    public class IpSettingArgument : IIpSettingArgument
    {
        /// <summary>
        /// The key for the arguments
        /// </summary>
        public string ArgumentKey { get; set; }

        /// <summary>
        /// A dynamic value
        /// </summary>
        public dynamic ArgumentValue { get; set; }

        /// <summary>
        /// Static Method to Get Common App Settings Arg
        /// </summary>
        /// <returns>An App Settings Arg</returns>
        public static IpSettingArgument GetStandardAppSettingArg()
        {
            return new IpSettingArgument { ArgumentKey = "ConfigSection", ArgumentValue = "appSettings" };
        }

        /// <summary>
        /// Static Method to Get Common Connection String Arg
        /// </summary>
        /// <returns>A Connection String Arg</returns>
        public static IpSettingArgument GetStandardConnectionStringArg()
        {
            return new IpSettingArgument { ArgumentKey = "ConfigSection", ArgumentValue = "connectionStrings" };
        }

        /// <summary>
        /// Static Method to Get Common Setting Id Arg
        /// </summary>
        /// <param name="value">The Value for the Setting Id</param>
        /// <returns>A Setting Id Arg</returns>
        public static IpSettingArgument GetStandardSettingIdArg(string value)
        {
            return new IpSettingArgument { ArgumentKey = "SettingId", ArgumentValue = value };
        }

        /// <summary>
        /// Static Method to Get Common Setting Value Arg
        /// </summary>
        /// <param name="value">The Value for the Setting Value</param>
        /// <returns>A Setting Value Arg</returns>
        public static IpSettingArgument GetStandardSettingValueArg(string value)
        {
            return new IpSettingArgument { ArgumentKey = "SettingValue", ArgumentValue = value };
        }

        /// <summary>
        /// Static Method to build setting arguments to get a setting from the configuration
        /// </summary>
        /// <param name="settingName">The name of the setting</param>
        /// <returns>A predefined set of args</returns>
        public static IList<IIpSettingArgument> GetConfigAppSetting(string settingName)
        {
            return new List<IIpSettingArgument>
            {
                GetStandardAppSettingArg(),
                GetStandardSettingIdArg(settingName)
            };
        }

        /// <summary>
        /// Static Method to build setting arguments to get a connectionString from the configuration
        /// </summary>
        /// <param name="connStringName">The name of the connection string</param>
        /// <returns>A predefined set of args</returns>
        public static IList<IIpSettingArgument> GetConfigConnString(string connStringName)
        {
            return new List<IIpSettingArgument>
            {
                GetStandardConnectionStringArg(),
                GetStandardSettingIdArg(connStringName)
            };
        }
    }
}
