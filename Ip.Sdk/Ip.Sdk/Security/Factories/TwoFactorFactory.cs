using Ip.Sdk.Commons.Enumerations;
using Ip.Sdk.Security.AuthObjects;

namespace Ip.Sdk.Security.Factories
{
    /// <summary>
    /// Builds two factor authentication types
    /// </summary>
    public class TwoFactorFactory
    {
        /// <summary>
        /// Overridable factory method for building a two factor destination object
        /// </summary>
        /// <param name="method">The method of two factor authentication</param>
        /// <returns>The base destination object</returns>
        public virtual BaseTwoFactorDestination GetTwoFactorDestination(TwoFactorMethod method)
        {
            switch(method)
            {
                case TwoFactorMethod.Email:
                    return new EmailTwoFactorDestination();

                case TwoFactorMethod.PhoneCall:
                    return new TelephoneTwoFactorDestination();

                case TwoFactorMethod.Sms:
                    return new SmsTwoFactorDestination();

                default:
                    return new EmailTwoFactorDestination();
            }
        }

        /// <summary>
        /// Overridable factory method for building a two factor destination object including its value
        /// </summary>
        /// <param name="method">The method of two factor authentication</param>
        /// <param name="destinationValue">The value to use for the destination</param>
        /// <returns>The base destination object</returns>
        public virtual BaseTwoFactorDestination GetTwoFactorDestination(TwoFactorMethod method, string destinationValue)
        {
            BaseTwoFactorDestination retVal = null;

            switch (method)
            {
                case TwoFactorMethod.Email:
                    retVal = new EmailTwoFactorDestination();
                    break;

                case TwoFactorMethod.PhoneCall:
                    retVal = new TelephoneTwoFactorDestination();
                    break;

                case TwoFactorMethod.Sms:
                    retVal = new SmsTwoFactorDestination();
                    break;

                default:
                    retVal = new EmailTwoFactorDestination();
                    break;
            }

            retVal.SetDestination(destinationValue);

            return retVal;
        }
    }
}
