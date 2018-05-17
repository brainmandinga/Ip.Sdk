namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// A claim is a key value pair that the user has authorization to
    /// </summary>
    public interface IIpClaim
    {
        /// <summary>
        /// The claim's key
        /// </summary>
        string ClaimKey { get; set; }

        /// <summary>
        /// The claim's value
        /// </summary>
        object ClaimValue { get; set; }
    }
}
