using Ip.Sdk.Commons.Arguments.Interfaces;
using Ip.Sdk.Commons.Validators;
using Ip.Sdk.Configuration.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ip.Sdk.Configuration
{
    /// <summary>
    /// Abstract base class for settings helpers
    /// </summary>
    public abstract class IpBaseSettingsHelper : IIpBaseSettingsHelper
    {
        /// <summary>
        /// Validates that the args have the required keys present
        /// </summary>
        /// <param name="args">The arguments to validate</param>
        public virtual IList<string> ValidateSettingsArgs(IList<IIpArgument> args)
        {
            try
            {
                var retVal = new List<string>();
                var results = new List<IList<IpValidationResult>>();

                foreach (var a in args)
                {
                    results.Add(a.Validate());
                }

                retVal.AddRange(results.SelectMany(r => r.Where(v => !v.IsValid)).Select(fv => fv.ValidationMessage));

                return retVal;
            }
            catch (Exception ex)
            {
                throw new IpSettingException("Validation of the settings failed.", ex);
            }
        }

        /// <summary>
        /// Gets a setting by its Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public abstract object GetSetting(IList<IIpArgument> args);

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public abstract void SaveSetting(IList<IIpArgument> args);

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public abstract void DeleteSetting(IList<IIpArgument> args);
    }
}
