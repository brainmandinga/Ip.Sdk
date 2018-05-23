using Ip.Sdk.Commons.Validators.Enumerations;
using Ip.Sdk.Commons.Validators.Interfaces;
using System;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Validates that a string matches a value
    /// </summary>
    public class IpStringValueValidator : IIpValidator
    {
        /// <summary>
        /// The value to validate
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The value to compare to
        /// </summary>
        public string CompareTo { get; set; }

        /// <summary>
        /// Is the validator case sensitive
        /// </summary>
        public bool IsCaseSensitive { get; set; }

        /// <summary>
        /// The type of comparison to do 
        /// </summary>
        public IpStringValidationType ValidationType { get; set; }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="compareTo">The value to compare to</param>
        /// <param name="isCaseSensitive">Indicates if the comparison is case sensitive, defaults to false</param>
        /// <param name="validationType">The type of validation to perform (StartsWith, EndsWith, Contains, Equality), defaults to equality</param>
        public IpStringValueValidator(string value, string compareTo, bool isCaseSensitive = false, IpStringValidationType validationType = IpStringValidationType.Equality)
        {
            Value = value;
            CompareTo = compareTo;
            IsCaseSensitive = isCaseSensitive;
            ValidationType = validationType;
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public virtual IpValidationResult Validate()
        {
            switch (ValidationType)
            {
                case IpStringValidationType.StartsWith:
                    return CompareStartsWith();

                case IpStringValidationType.EndsWith:
                    return CompareEndsWith();

                case IpStringValidationType.Contains:
                    return CompareContains();

                case IpStringValidationType.Equality:
                    return CompareEquality();

                default:
                    return CompareEquality();
            }
        }

        /// <summary>
        /// Does a starts with comparison
        /// </summary>
        /// <returns>Rerturns the validation result</returns>
        protected virtual IpValidationResult CompareStartsWith()
        {
            var retVal = new IpValidationResult();

            if (IsCaseSensitive && !Value.StartsWith(CompareTo))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case sensitive comparison of the values is not matching";
            }
            else if (!IsCaseSensitive && !Value.StartsWith(CompareTo, StringComparison.OrdinalIgnoreCase))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case insensitive comparison of the values is not matching";
            }

            return retVal;
        }

        /// <summary>
        /// Does a ends with comparison
        /// </summary>
        /// <returns>Rerturns the validation result</returns>
        protected virtual IpValidationResult CompareEndsWith()
        {
            var retVal = new IpValidationResult();

            if (IsCaseSensitive && !Value.EndsWith(CompareTo))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case sensitive comparison of the values is not matching";
            }
            else if (!IsCaseSensitive && !Value.EndsWith(CompareTo, StringComparison.OrdinalIgnoreCase))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case insensitive comparison of the values is not matching";
            }

            return retVal;
        }

        /// <summary>
        /// Does a contains comparison
        /// </summary>
        /// <returns>Rerturns the validation result</returns>
        protected virtual IpValidationResult CompareContains()
        {
            var retVal = new IpValidationResult();

            if (IsCaseSensitive && !Value.Contains(CompareTo))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case sensitive comparison of the values is not matching";
            }
            else if (!IsCaseSensitive && !Value.ToLower().Contains(CompareTo))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case insensitive comparison of the values is not matching";
            }

            return retVal;
        }

        /// <summary>
        /// Does an equality comparison
        /// </summary>
        /// <returns>Rerturns the validation result</returns>
        protected virtual IpValidationResult CompareEquality()
        {
            var retVal = new IpValidationResult();

            if (IsCaseSensitive && !Value.Equals(CompareTo))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case sensitive comparison of the values is not matching";
            }
            else if (!IsCaseSensitive && !Value.Equals(CompareTo, StringComparison.OrdinalIgnoreCase))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = "The case insensitive comparison of the values is not matching";
            }

            return retVal;
        }
    }
}
