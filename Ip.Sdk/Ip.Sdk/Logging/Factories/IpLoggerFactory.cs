using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using Ip.Sdk.Logging.Interfaces;

namespace Ip.Sdk.Logging.Factories
{
    /// <summary>
    /// Factory for generating IP Logger Objects
    /// </summary>
    public class IpLoggerFactory
    {
        /// <summary>
        /// Gets a database logger object
        /// </summary>
        /// <param name="logger">An optionally injectible logger object</param>
        /// <param name="dataLayer">The data layer for the database logger to use</param>
        /// <returns>A logger</returns>
        public IIpBaseLogger GetLogger(IIpDatabaseLogger logger, IIpBaseDataLayer dataLayer)
        {
            return logger ?? new IpDatabaseLogger();
        }

        /// <summary>
        /// Gets an event viewer logger object
        /// </summary>
        /// <param name="logger">An optionally injectible logger object</param>
        /// <returns>A logger</returns>
        public IIpBaseLogger GetLogger(IIpEventViewerLogger logger)
        {
            return logger ?? new IpEventViewerLogger();
        }

        /// <summary>
        /// Gets a file logger object
        /// </summary>
        /// <param name="logger">An optionally injectible logger object</param>
        /// <returns>A logger</returns>
        public IIpBaseLogger GetLogger(IIpFileLogger logger)
        {
            return logger ?? new IpFileLogger();
        }
    }
}
