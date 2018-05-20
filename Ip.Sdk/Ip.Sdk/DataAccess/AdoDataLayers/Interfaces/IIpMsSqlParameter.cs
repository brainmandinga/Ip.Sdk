using System.Data;
using System.Data.SqlClient;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Interfaces
{
    /// <summary>
    /// Interfaces for the MsSqlParameter
    /// </summary>
    public interface IIpMsSqlParameter : IIpBaseParameter<SqlParameter, SqlDbType>
    {
    }
}
