using Ip.Sdk.Commons.Validators.Enumerations;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Checks for inequality on a char
    /// </summary>
    public class IpCharInequalityValidator : IpInequalityValidator<char>
    {
        /// <summary>
        /// Overloaded constructor setting the values
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="compareTo">The value to compare to</param>
        /// <param name="validationType">The type of validation to perform</param>
        public IpCharInequalityValidator(char value, char compareTo, IpInequalityValidationType validationType)
            : base(value, compareTo, validationType) { }

        /// <summary>
        /// Does a greater than comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult GreaterThanComparison()
        {
            var retVal = new IpValidationResult();

            if (Value > CompareTo)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The value is not greater than the comparison, causing the validation to fail.";

            return retVal;
        }

        /// <summary>
        /// Does a greater than or equal to comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult GreaterThanOrEqualComparison()
        {
            var retVal = new IpValidationResult();

            if (Value >= CompareTo)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The value is not greater than or equal to the comparison, causing the validation to fail.";

            return retVal;
        }

        /// <summary>
        /// Does a less than comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult LessThanComparison()
        {
            var retVal = new IpValidationResult();

            if (Value < CompareTo)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The value is not less than the comparison, causing the validation to fail.";

            return retVal;
        }

        /// <summary>
        /// Does a less than or equal to comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected override IpValidationResult LessThanOrEqualComparison()
        {
            var retVal = new IpValidationResult();

            if (Value <= CompareTo)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The value is not less than or equal to the comparison, causing the validation to fail.";

            return retVal;
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
