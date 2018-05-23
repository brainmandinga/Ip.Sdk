using Ip.Sdk.Commons.Validators.Interfaces;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Validates if an object has been provided
    /// </summary>
    public class IpRequiredObjectValidator : IIpValidator
    {
        /// <summary>
        /// The object to validate
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Overloaded constructor to set values
        /// </summary>
        /// <param name="value">The object to be validated</param>
        public IpRequiredObjectValidator(object value)
        {
            Value = value;
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public IpValidationResult Validate()
        {
            var retVal = new IpValidationResult();

            if (Value == null)
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The required value was not provided causing validation to fail";
            }

            return retVal;
        }
    }
}
