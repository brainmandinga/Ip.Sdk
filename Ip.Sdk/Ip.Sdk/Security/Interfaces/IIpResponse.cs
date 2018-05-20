namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// Interface for the base IP Response object
    /// </summary>
    public interface IIpResponse
    {
        /// <summary>
        /// A status enumeration
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// The message for the response
        /// </summary>
        string ResponseMessage { get; set; }
    }
}
