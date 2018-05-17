using Ip.Sdk.Commons.Enumerations;

namespace Ip.Sdk.Security.AuthObjects
{
    /// <summary>
    /// Two factor destination for email
    /// </summary>
    public class EmailTwoFactorDestination : BaseTwoFactorDestination
    {
        /// <summary>
        /// The Type of Two Factor Authentication
        /// </summary>
        public override TwoFactorMethod TwoFactorType { get { return TwoFactorMethod.Email; } }

        /// <summary>
        /// The regex for validating the value of this two factor authentication type
        /// </summary>
        public override string DestinationRegex { get { return ""; } }
    }
}
