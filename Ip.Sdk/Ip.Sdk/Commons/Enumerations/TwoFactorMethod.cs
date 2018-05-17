using System.ComponentModel;

namespace Ip.Sdk.Commons.Enumerations
{
    /// <summary>
    /// An enumeration describing the two factor methods usable
    /// </summary>
    public enum TwoFactorMethod
    {
        /// <summary>
        /// A telephone call
        /// </summary>
        [Description("Phone call")]
        PhoneCall,
        
        /// <summary>
        /// A text message
        /// </summary>
        [Description("Text message")]
        Sms,

        /// <summary>
        /// An email message
        /// </summary>
        [Description("Email message")]
        Email
    }
}
