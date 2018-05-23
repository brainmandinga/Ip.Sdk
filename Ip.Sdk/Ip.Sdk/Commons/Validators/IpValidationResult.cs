namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Object to hold the result of a validation
    /// </summary>
    public class IpValidationResult
    {
        /// <summary>
        /// Is it valid or not
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// The message from the validation
        /// </summary>
        public string ValidationMessage { get; set; }

        /// <summary>
        /// Default Constructor defaults to Valid
        /// </summary>
        public IpValidationResult()
        {
            IsValid = true;
            ValidationMessage = "Valid";
        }
    }
}
