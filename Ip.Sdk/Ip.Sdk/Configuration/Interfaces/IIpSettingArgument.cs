namespace Ip.Sdk.Configuration.Interfaces
{
    /// <summary>
    /// Interface for a setting argument for crud operations
    /// </summary>
    public interface IIpSettingArgument
    {
        /// <summary>
        /// The key for the argument
        /// </summary>
        string ArgumentKey { get; set; }

        /// <summary>
        /// A dynamic value
        /// </summary>
        dynamic ArgumentValue { get; set; }
    }
}
