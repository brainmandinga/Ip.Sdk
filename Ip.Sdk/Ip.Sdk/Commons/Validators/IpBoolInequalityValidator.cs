using Ip.Sdk.Commons.Validators.Enumerations;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Checks for inequality on a bool
    /// </summary>
    public class IpBoolInequalityValidator : IpInequalityValidator<bool>
    {
        /// <summary>
        /// Overloaded constructor setting the values
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="compareTo">The value to compare to</param>
        /// <param name="validationType">The type of validation to perform</param>
        public IpBoolInequalityValidator(bool value, bool compareTo, IpInequalityValidationType validationType)
            : base(value, compareTo, validationType) { }

        /// <summary>
        /// Does a greater than comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult GreaterThanComparison()
        {
            return new IpValidationResult
            {
                IsValid = true,
                ValidationMessage = "This comparison cannot be performed on a boolean value."
            };
        }

        /// <summary>
        /// Does a greater than or equal to comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult GreaterThanOrEqualComparison()
        {
            return new IpValidationResult
            {
                IsValid = true,
                ValidationMessage = "This comparison cannot be performed on a boolean value."
            };
        }

        /// <summary>
        /// Does a less than comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult LessThanComparison()
        {
            return new IpValidationResult
            {
                IsValid = true,
                ValidationMessage = "This comparison cannot be performed on a boolean value."
            };
        }

        /// <summary>
        /// Does a less than or equal to comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult LessThanOrEqualComparison()
        {
            return new IpValidationResult
            {
                IsValid = true,
                ValidationMessage = "This comparison cannot be performed on a boolean value."
            };
        }

        /// <summary>
        /// Does an equality comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult EqualComparison()
        {
            var retVal = new IpValidationResult();

            if (Value == CompareTo)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The value is not equal to the comparison, causing the validation to fail.";

            return retVal;
        }
    }
}
