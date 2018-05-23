using Ip.Sdk.Commons.Validators.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Validator to see if a string matches one of a collection
    /// </summary>
    public class IpStringInclusionValidator : IIpValidator
    {
        private IList<string> _valuesToCompare;

        /// <summary>
        /// The Value to check against the inclusion list
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Is the comparison case sensisitve
        /// </summary>
        public bool IsCaseSensitive { get; set; }

        /// <summary>
        /// The list to compare the value against, if it matches any of them, it is valid
        /// </summary>
        public IList<string> ValuesToCompare
        {
            get { return _valuesToCompare = (_valuesToCompare ?? new List<string>()); }
            set { _valuesToCompare = value; }
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public virtual IpValidationResult Validate()
        {
            var retVal = new IpValidationResult();

            foreach (var vtc in ValuesToCompare)
            {
                var validator = new IpStringValueValidator(Value, vtc, IsCaseSensitive);
                var isValid = validator.Validate().IsValid;
                
                //If we run into any valid values, return success
                if (isValid)
                {
                    return retVal;
                }
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "None of the values match the possible list, causing validation to fail";

            return retVal;
        }
    }
}
