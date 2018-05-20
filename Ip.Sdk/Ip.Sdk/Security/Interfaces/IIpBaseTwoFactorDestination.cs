namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// The Interface for the base two factor destination
    /// </summary>
    public interface IIpBaseTwoFactorDestination
    {
        /// <summary>
        /// A regex for the type of two factor authentication that's being used
        /// </summary>
        string DestinationRegex { get; }

        /// <summary>
        /// The message destination used for two factor authentication
        /// </summary>
        string TwoFactorMessageDestination { get; }

        /// <summary>
        /// Sets the destination value for two factor authentication
        /// </summary>
        /// <param name="destinationValue">The destination value to set</param>
        void SetDestination(string destinationValue);

        /// <summary>
        /// Sends the two factor message
        /// </summary>
        /// <param name="subject">The subject of the message</param>
        /// <param name="message">The message</param>
        void SendMessage(string subject, string message);
    }
}
