using Ip.Sdk.Commons.Configuration.Interfaces;

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
    }
}
