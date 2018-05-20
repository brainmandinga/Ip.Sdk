using Ip.Sdk.Commons.Enumerations;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System.Text.RegularExpressions;

namespace Ip.Sdk.Security.AuthObjects
{
    /// <summary>
    /// Abstract class describing a base two factor authentication object
    /// </summary>
    public abstract class BaseTwoFactorDestination
    {
        /// <summary>
        /// The type of two factor authentication to use
        /// </summary>
        public abstract TwoFactorMethod TwoFactorType { get; }

        /// <summary>
        /// A regex for the type of two factor authentication that's being used
        /// </summary>
        public abstract string DestinationRegex { get; }

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
    }
}
