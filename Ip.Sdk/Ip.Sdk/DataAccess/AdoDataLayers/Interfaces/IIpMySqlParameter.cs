using MySql.Data.MySqlClient;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Interfaces
{
    /// <summary>
    /// Interfaces for the MySqlParameter
    /// </summary>
    public interface IIpMySqlParameter : IIpBaseParameter<MySqlParameter, MySqlDbType>
    {
    }
}
