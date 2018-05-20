using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Interfaces
{
    /// <summary>
    /// Interface for the base data layer
    /// </summary>
    public interface IIpBaseDataLayer
    {
        /// <summary>
        /// The Connection string
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// A Factory for a specific provider to create a connection string
        /// </summary>
        DbProviderFactory ProviderFactory { get; }

        /// <summary>
        /// The provider of the database
        /// </summary>
        string DatabaseProvider { get; set; }

        /// <summary>
        /// The timeout for queries
        /// </summary>
        int QueryTimeout { get; set; }

        /// <summary>
        /// Executes a stored procedure that doesn't return data
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The number of rows affected</returns>
        int ExecuteNonQuery(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Executes a stored procedure that doesn't return data asynchronously
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The number of rows affected</returns>
        Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Gets a typed collection as a return from the database
        /// </summary>
        /// <typeparam name="T">The type of data</typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A collection of objects of type T returned from the database</returns>
        IList<T> GetTypedList<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Gets a typed collection as a return from the database asynchronously
        /// </summary>
        /// <typeparam name="T">The type of data</typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A collection of objects of type T returned from the database</returns>
        Task<IList<T>> GetTypedListAsync<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Gets a scalar value from a query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first column of the first row of the results cast to T</returns>
        T GetScalar<T>(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Gets a scalar value from a query asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first column of the first row of the results cast to T</returns>
        Task<T> GetScalarAsync<T>(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Gets a single row from a query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first row returned from the Query converted to an object of type T</returns>
        T GetSingleRow<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Gets a single row from a query asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first row returned from the Query converted to an object of type T</returns>
        Task<T> GetSingleRowAsync<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Queries the database and builds a datatable of the results
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A DataTable from the results of the query</returns>
        DataTable GetDataTable(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null);

        /// <summary>
        /// Queries the database and builds a datatable of the results asynchronously
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A DataTable from the results of the query</returns>
        Task<DataTable> GetDataTableAsync(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null);
    }
}
