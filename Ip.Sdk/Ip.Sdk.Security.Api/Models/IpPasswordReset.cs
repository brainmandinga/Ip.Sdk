using Ip.Sdk.Security.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Security.Api.Models
{
    public class IpPasswordReset : IIpPasswordReset
    {
        private IList<IIpSecurityQuestion> _securityQuestions;

        /// <summary>
        /// The password for creation
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The confirm password for creation
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// A collection of security questions/answers
        /// </summary>
        public IList<IIpSecurityQuestion> SecurityQuestions
        {
            get { return _securityQuestions = (_securityQuestions ?? new List<IIpSecurityQuestion>()); }
            set { _securityQuestions = value; }
        }
    }
}