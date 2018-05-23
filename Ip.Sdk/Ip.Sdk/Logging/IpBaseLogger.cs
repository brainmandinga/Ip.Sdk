using Ip.Sdk.Commons.Arguments.Interfaces;
using Ip.Sdk.Commons.Validators;
using Ip.Sdk.ErrorHandling;
using Ip.Sdk.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ip.Sdk.Logging
{
    /// <summary>
    /// This abstract class describes the base properties and actions of the logging system
    /// </summary>
    public abstract class IpBaseLogger : IIpBaseLogger
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
                throw new IpLoggingException("Validation of the logging args failed.", ex);
            }
        }

        /// <summary>
        /// Gets log entries
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        /// <returns>A collection of log entries</returns>
        public abstract IList<T> GetLogDataCollection<T>(IList<IIpArgument> args) where T : IIpLog, IIpLogEntry;

        /// <summary>
        /// Gets a log entry
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        /// <returns>A log entry</returns>
        public abstract T GetLogData<T>(IList<IIpArgument> args) where T : IIpLog, IIpLogEntry;

        /// <summary>
        /// Saves a log entry
        /// </summary>
        /// <param name="args">Arguments for the processing</param>
        public abstract void WriteLogData(IList<IIpArgument> args);

        /// <summary>
        /// Deletes a log entry
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        public abstract void DeleteLogData(IList<IIpArgument> args);
    }
}
