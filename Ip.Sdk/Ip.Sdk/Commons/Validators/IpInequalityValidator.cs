using Ip.Sdk.Commons.Validators.Enumerations;
using Ip.Sdk.Commons.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Checks for inequality on specific types
    /// </summary>
    /// <typeparam name="T">The type to compare</typeparam>
    public abstract class IpInequalityValidator<T> : IIpValidator
    {
        /// <summary>
        /// The Value being compared
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The Value to compare to
        /// </summary>
        public T CompareTo { get; set; }

        /// <summary>
        /// The Type of Validation to do
        /// </summary>
        public IpInequalityValidationType ValidationType { get; set; }

        /// <summary>
        /// Overloaded constructor setting the values
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="compareTo">The value to compare to</param>
        /// <param name="validationType">The type of validation to perform</param>
        protected IpInequalityValidator(T value, T compareTo, IpInequalityValidationType validationType)
        {
            Value = value;
            CompareTo = compareTo;
            ValidationType = ValidationType;
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public virtual IpValidationResult Validate()
        {
            switch(ValidationType)
            {
                case IpInequalityValidationType.GreaterThan:
                    return GreaterThanComparison();

                case IpInequalityValidationType.GreaterThanOrEqual:
                    return GreaterThanOrEqualComparison();

                case IpInequalityValidationType.LessThan:
                    return LessThanComparison();

                case IpInequalityValidationType.LessThanOrEqual:
                    return LessThanOrEqualComparison();

                case IpInequalityValidationType.Equal:
                    return EqualComparison();

                default:
                    return EqualComparison();
            }
        }

        /// <summary>
        /// Does a greater than comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected abstract IpValidationResult GreaterThanComparison();

        /// <summary>
        /// Does a greater than or equal to comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected abstract IpValidationResult GreaterThanOrEqualComparison();

        /// <summary>
        /// Does a less than comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected abstract IpValidationResult LessThanComparison();

        /// <summary>
        /// Does a less than or equal to comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected abstract IpValidationResult LessThanOrEqualComparison();

        /// <summary>
        /// Does an equality comparison
        /// </summary>
        /// <returns>Returns a validation result</returns>
        protected abstract IpValidationResult EqualComparison();
    }
}
