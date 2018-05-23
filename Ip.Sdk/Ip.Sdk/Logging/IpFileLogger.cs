using Ip.Sdk.Commons.Arguments.Interfaces;
using Ip.Sdk.Logging.Interfaces;
using System;
using System.Collections.Generic;

namespace Ip.Sdk.Logging
{
    /// <summary>
    /// Handles logging to the file system
    /// </summary>
    internal class IpFileLogger : IpBaseLogger, IIpFileLogger
    {
        /// <summary>
        /// Gets log entries
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        /// <returns>A collection of log entries</returns>
        public override IList<T> GetLogDataCollection<T>(IList<IIpArgument> args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a log entry
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        /// <returns>A log entry</returns>
        public override T GetLogData<T>(IList<IIpArgument> args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves a log entry
        /// </summary>
        /// <param name="args">Arguments for the processing</param>
        public override void WriteLogData(IList<IIpArgument> args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a log entry
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        public override void DeleteLogData(IList<IIpArgument> args)
        {
            throw new NotImplementedException();
        }
    }
}
