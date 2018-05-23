using Ip.Sdk.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip.Sdk.Logging
{
    /// <summary>
    /// Handles Logging to the Event Viewer
    /// </summary>
    internal class IpEventViewerLogger : IpBaseLogger, IIpEventViewerLogger
    {
    }
}
