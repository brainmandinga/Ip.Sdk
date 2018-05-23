using System;

namespace Ip.Sdk.Logging.Interfaces
{
    /// <summary>
    /// Interface for a log entry
    /// </summary>
    public interface IIpLogEntry
    {
        /// <summary>
        /// A string version of the Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Log Entry Summary
        /// </summary>
        string LogEntrySummary { get; set; }

        /// <summary>
        /// The Log Entry
        /// </summary>
        string LogEntryDetail { get; set; }

        /// <summary>
        /// The date/time of the log entry
        /// </summary>
        DateTime LogEntryDateTime { get; set; }

        /// <summary>
        /// The epoch format data for the log entry measured in seconds, NOT milliseconds
        /// </summary>
        long LogEntryEpoch { get; set; }

        /// <summary>
        /// An integer based log level
        /// </summary>
        int LogLevel { get; set; }

        /// <summary>
        /// The log level as a string
        /// </summary>
        string LogLevelString { get; set; }

        /// <summary>
        /// The source of where the entry comes from
        /// </summary>
        string LogEntrySource { get; set; }
    }
}
