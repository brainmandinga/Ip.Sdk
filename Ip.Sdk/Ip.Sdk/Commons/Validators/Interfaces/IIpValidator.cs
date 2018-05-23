namespace Ip.Sdk.Commons.Validators.Interfaces
{
    /// <summary>
    /// Interface for a validator to implement
    /// </summary>
    public interface IIpValidator
    {
        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        IpValidationResult Validate();
    }
}
