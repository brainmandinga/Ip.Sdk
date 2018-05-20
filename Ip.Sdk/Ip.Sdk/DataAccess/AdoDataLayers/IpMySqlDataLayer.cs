using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;

namespace Ip.Sdk.DataAccess.AdoDataLayers
{
    /// <summary>
    /// My SQL Data Layer
    /// </summary>
    internal class IpMySqlDataLayer : IpBaseDataLayer, IIpMySqlDataLayer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">The Connection String</param>
        public IpMySqlDataLayer(string connectionString)
            : base(connectionString, "MySql.Data.MySqlClient") { }
    }
}
