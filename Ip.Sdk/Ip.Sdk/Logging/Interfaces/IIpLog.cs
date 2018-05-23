using System;
using System.Collections.Generic;

namespace Ip.Sdk.Logging.Interfaces
{
    /// <summary>
    /// Interface for a log
    /// </summary>
    public interface IIpLog
    {
        /// <summary>
        /// The string Id of the log
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The name of the log
        /// </summary>
        string LogName { get; set; }

        /// <summary>
        /// The entries associated with the log
        /// </summary>
        IList<IIpLogEntry> LogEntries { get; set; }
    }
}
