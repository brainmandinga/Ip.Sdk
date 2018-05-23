using Ip.Sdk.Commons.Validators.Interfaces;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Validates if a required string is not null, or possibly empty
    /// </summary>
    public class IpRequiredStringValidator : IIpValidator
    {
        /// <summary>
        /// The value being validated
        /// </summary>
        protected string Value { get; private set; }

        /// <summary>
        /// Indicates if the string can be empty. If so this just does a null check
        /// </summary>
        protected bool CanBeEmpty { get; private set; }

        /// <summary>
        /// Overloaded constructor that takes the values used for validation
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="canBeEmpty">Can the string be empty and still valid, defaults to false</param>
        public IpRequiredStringValidator(string value, bool canBeEmpty = false)
        {
            Value = value;
            CanBeEmpty = canBeEmpty;
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public virtual IpValidationResult Validate()
        {
            var retVal = new IpValidationResult();

            if (CanBeEmpty && Value == null)
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The validated value cannot be null";
            }
            else if (!CanBeEmpty && string.IsNullOrWhiteSpace(Value))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The validated value cannot be null or empty";
            }

            return retVal;
        }
    }
}
