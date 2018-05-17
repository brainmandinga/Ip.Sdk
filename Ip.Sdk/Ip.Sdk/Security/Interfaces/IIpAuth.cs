namespace Ip.Sdk.Security.Interfaces
{
    public interface IIpAuth
    {
        /// <summary>
        /// The username to authenticate
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The password to authenticate
        /// </summary>
        string Password { get; set; }
    }
}
