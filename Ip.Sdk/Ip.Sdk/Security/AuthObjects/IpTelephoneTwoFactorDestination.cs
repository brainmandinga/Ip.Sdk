﻿using Ip.Sdk.Security.Interfaces;

namespace Ip.Sdk.Security.AuthObjects
{
    /// <summary>
    /// Two factor destination for phone call
    /// </summary>
    public class IpTelephoneTwoFactorDestination : IpBaseTwoFactorDestination, IIpTelephoneTwoFactorDestination
    {
        /// <summary>
        /// Sends the two factor message
        /// </summary>
        /// <param name="subject">The subject of the message</param>
        /// <param name="message">The message</param>
        public override void SendMessage(string subject, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
