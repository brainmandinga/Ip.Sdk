using Ip.Sdk.Logging.Interfaces;
using System;

namespace Ip.Sdk.Logging
{
    /// <summary>
    /// IP Log Entry class
    /// </summary>
    public class IpLogEntry : IIpLogEntry
    {
        /// <summary>
        /// A string version of the Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Log Entry Summary
        /// </summary>
        public string LogEntrySummary { get; set; }

        /// <summary>
        /// The Log Entry
        /// </summary>
        public string LogEntryDetail { get; set; }

        /// <summary>
        /// The date/time of the log entry
        /// </summary>
        public DateTime LogEntryDateTime { get; set; }

        /// <summary>
        /// The epoch format data for the log entry measured in seconds, NOT milliseconds
        /// </summary>
        public long LogEntryEpoch { get; set; }

        /// <summary>
        /// An integer based log level
        /// </summary>
        public int LogLevel { get; set; }

        /// <summary>
        /// The log level as a string
        /// </summary>
        public string LogLevelString { get; set; }

        /// <summary>
        /// The source of where the entry comes from
        /// </summary>
        public string LogEntrySource { get; set; }
    }
}
