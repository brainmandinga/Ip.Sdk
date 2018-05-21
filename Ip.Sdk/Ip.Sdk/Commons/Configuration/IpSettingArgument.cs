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
    }
}
