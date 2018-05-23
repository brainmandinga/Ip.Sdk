using Ip.Sdk.Commons.Validators;
using Ip.Sdk.Commons.Validators.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Commons.Arguments.Interfaces
{
    /// <summary>
    /// Interface for a setting argument for crud operations
    /// </summary>
    public interface IIpArgument
    {
        /// <summary>
        /// The key for the argument
        /// </summary>
        string ArgumentKey { get; set; }

        /// <summary>
        /// A dynamic value
        /// </summary>
        dynamic ArgumentValue { get; set; }

        /// <summary>
        /// Validators for the Keys
        /// </summary>
        IList<IIpValidator> KeyValidators { get; set; }

        /// <summary>
        /// Validators for the values
        /// </summary>
        IList<IIpValidator> ValueValidators { get; set; }

        /// <summary>
        /// Validates the Settings Argument
        /// </summary>
        /// <returns>A Validation Result Argument</returns>
        IList<IpValidationResult> Validate();

        /// <summary>
        /// Validates the Settings Argument
        /// </summary>
        /// <param name="keyValidators">The validators for the keys</param>
        /// <param name="valueValidators">The validators for the values</param>
        /// <returns>A Validation Result Argument</returns>
        IList<IpValidationResult> Validate(IList<IIpValidator> keyValidators, IList<IIpValidator> valueValidators);
    }
}
