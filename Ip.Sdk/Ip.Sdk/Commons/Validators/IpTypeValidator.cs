using Ip.Sdk.Commons.Validators.Interfaces;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Validator for validating the Type of a value
    /// </summary>
    public class IpTypeValidator<T> : IIpValidator
    {
        /// <summary>
        /// The value to check the type of
        /// </summary>
        public object TypeValue { get; set; }

        /// <summary>
        /// Overloaded constructor taking the value to validate
        /// </summary>
        /// <param name="typeValue">The object to check the type against</param>
        public IpTypeValidator(object typeValue)
        {
            TypeValue = typeValue;
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public virtual IpValidationResult Validate()
        {
            var retVal = new IpValidationResult();

            if (!(TypeValue is T))
            {
                retVal.IsValid = false;
                retVal.ValidationMessage = string.Format("The value was not of type {0} and is not valid.", typeof(T).FullName);
            }

            return retVal;
        }
    }
}
