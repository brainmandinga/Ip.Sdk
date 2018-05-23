using Ip.Sdk.Logging.Interfaces;
using System.Collections.Generic;

namespace Ip.Sdk.Logging
{
    /// <summary>
    /// Implementation of an IIpLog
    /// </summary>
    public class IpLog : IIpLog
    {
        private IList<IIpLogEntry> _logEntries;

        /// <summary>
        /// The string Id of the log
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the log
        /// </summary>
        public string LogName { get; set; }

        /// <summary>
        /// The entries associated with the log
        /// </summary>
        public IList<IIpLogEntry> LogEntries
        {
            get { return _logEntries = (_logEntries ?? new List<IIpLogEntry>()); }
            set { _logEntries = value; }
        }
    }
}
