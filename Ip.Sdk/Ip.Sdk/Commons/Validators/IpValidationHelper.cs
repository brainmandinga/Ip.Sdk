using Ip.Sdk.Commons.Validators.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Static class to provide easy to use components for common validation tasks
    /// </summary>
    public static class IpValidationHelper
    {
        /// <summary>
        /// Validates items for validators
        /// </summary>
        /// <param name="validators">The validators to validate</param>
        /// <returns></returns>
        public static IList<string> Validate(IList<IIpValidator> validators)
        {
            var retVal = new List<string>();
            var results = new List<IpValidationResult>();

            foreach (var v in validators)
            {
                results.Add(v.Validate());
            }

            retVal.AddRange(results.Where(r => !r.IsValid).Select(r => r.ValidationMessage));

            return retVal;
        }
    }
}
