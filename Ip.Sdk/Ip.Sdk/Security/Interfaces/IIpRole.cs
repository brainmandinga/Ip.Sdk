namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// A role for a user to be placed into
    /// </summary>
    public interface IIpRole
    {
        /// <summary>
        /// The name of the role
        /// </summary>
        string RoleName { get; set; }
    }
}
