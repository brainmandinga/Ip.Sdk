using Ip.Sdk.ErrorHandling.CustomExceptions;
using Ip.Sdk.Security.Interfaces;
using System.Text.RegularExpressions;

namespace Ip.Sdk.Security
{
    /// <summary>
    /// Abstract class describing a base two factor authentication object
    /// </summary>
    public abstract class IpBaseTwoFactorDestination : IIpBaseTwoFactorDestination
    {
        /// <summary>
        /// A regex for the type of two factor authentication that's being used
        /// </summary>
        public string DestinationRegex { get; }

        /// <summary>
        /// The message destination used for two factor authentication
        /// </summary>
        public string TwoFactorMessageDestination { get; protected set; }
        
        /// <summary>
        /// Sets the destination value for two factor authentication
        /// </summary>
        /// <param name="destinationValue">The destination value to set</param>
        public virtual void SetDestination(string destinationValue)
        {
            if (!Regex.Match(destinationValue, DestinationRegex, RegexOptions.IgnoreCase).Success)
                throw new IpTwoFactorValueException(string.Format("Value: {0} didn't match the regex: {1}", destinationValue, DestinationRegex));

            TwoFactorMessageDestination = destinationValue;
        }

        /// <summary>
        /// Sends the two factor message
        /// </summary>
        /// <param name="subject">The subject of the message</param>
        /// <param name="message">The message</param>
        public abstract void SendMessage(string subject, string message);
    }
}
