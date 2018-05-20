using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;

namespace Ip.Sdk.DataAccess.AdoDataLayers
{
    /// <summary>
    /// Microsoft SQL Server Data Layer
    /// </summary>
    internal class IpMsSqlDataLayer : IpBaseDataLayer, IIpMsSqlDataLayer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">The Connection String</param>
        public IpMsSqlDataLayer(string connectionString)
            : base(connectionString, "System.Data.SqlClient") { }
    }
}
