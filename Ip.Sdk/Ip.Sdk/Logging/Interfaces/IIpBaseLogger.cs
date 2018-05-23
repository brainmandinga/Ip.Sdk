using Ip.Sdk.Commons.Arguments.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Logging.Interfaces
{
    /// <summary>
    /// Interface for Base Logger
    /// </summary>
    public interface IIpBaseLogger
    {
        /// <summary>
        /// Gets log entries
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        /// <returns>A collection of log entries</returns>
        IList<T> GetLogDataCollection<T>(IList<IIpArgument> args) where T : IIpLog, IIpLogEntry;

        /// <summary>
        /// Gets a log entry
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        /// <returns>A log entry</returns>
        T GetLogData<T>(IList<IIpArgument> args) where T : IIpLog, IIpLogEntry;

        /// <summary>
        /// Saves a log entry
        /// </summary>
        /// <param name="args">Arguments for the processing</param>
        void WriteLogData(IList<IIpArgument> args);

        /// <summary>
        /// Deletes a log entry
        /// </summary>
        /// <param name="args">Arguments for processing</param>
        void DeleteLogData(IList<IIpArgument> args);
    }
}
