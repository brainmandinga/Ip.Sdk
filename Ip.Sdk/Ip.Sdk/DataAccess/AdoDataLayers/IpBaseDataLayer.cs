using Ip.Sdk.Configuration;
using Ip.Sdk.Configuration.Factories;
using Ip.Sdk.Configuration.Interfaces;
using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Ip.Sdk.DataAccess.AdoDataLayers
{
    /// <summary>
    /// Delegate method for reading a data record into an object of type T
    /// </summary>
    /// <param name="record">The IDataRecord (typically a Data Reader)</param>
    /// <typeparam name="T">The Type of Object to return</typeparam>
    public delegate T BuildDataObject<out T>(IDataRecord record);

    /// <summary>
    /// Base class as an abstract for the data layers
    /// </summary>
    public abstract class IpBaseDataLayer : IIpBaseDataLayer
    {
        /// <summary>
        /// The Connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// A Factory for a specific provider to create a connection string
        /// </summary>
        public DbProviderFactory ProviderFactory { get; private set; }

        /// <summary>
        /// The provider of the database
        /// </summary>
        public string DatabaseProvider { get; set; }

        /// <summary>
        /// The timeout for queries
        /// </summary>
        public int QueryTimeout { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">The Connection String</param>
        /// <param name="provider">The Provider for the connection</param>
        protected IpBaseDataLayer(string connectionString, string provider)
        {
            ConnectionString = connectionString;
            ProviderFactory = DbProviderFactories.GetFactory(provider);
            DatabaseProvider = provider;

            var configHelper = new IpSettingsFactory().GetSettingsHelper((IIpConfigurationSettingsHelper)null);
            QueryTimeout = configHelper.GetSetting(IpSettingArgument.GetConfigAppSetting("QueryTimeoutInSeconds")).ChangeType<int>();
        }

        /// <summary>
        /// Executes a stored procedure that doesn't return data
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The number of rows affected</returns>
        public virtual int ExecuteNonQuery(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.", 
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Executes a stored procedure that doesn't return data asynchronously
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The number of rows affected</returns>
        public virtual async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        return await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Gets a typed collection as a return from the database
        /// </summary>
        /// <typeparam name="T">The type of data</typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A collection of objects of type T returned from the database</returns>
        public virtual IList<T> GetTypedList<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();
            var retVal = new List<T>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                retVal.Add(buildObject(reader));
                            }
                        }
                    }
                }

                return retVal;
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Gets a typed collection as a return from the database asynchronously
        /// </summary>
        /// <typeparam name="T">The type of data</typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A collection of objects of type T returned from the database</returns>
        public virtual async Task<IList<T>> GetTypedListAsync<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();
            var retVal = new List<T>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                retVal.Add(buildObject(reader));
                            }
                        }
                    }
                }

                return retVal;
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Gets a scalar value from a query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first column of the first row of the results cast to T</returns>
        public virtual T GetScalar<T>(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        var result = command.ExecuteScalar();

                        return result.ChangeType<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Gets a scalar value from a query asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first column of the first row of the results cast to T</returns>
        public virtual async Task<T> GetScalarAsync<T>(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        var result = await command.ExecuteScalarAsync();

                        return result.ChangeType<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Gets a single row from a query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first row returned from the Query converted to an object of type T</returns>
        public virtual T GetSingleRow<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return buildObject(reader);
                            }
                        }
                    }
                }

                return default(T);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Gets a single row from a query asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="buildObject">The delegate method that runs to build an object of type T</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>The first row returned from the Query converted to an object of type T</returns>
        public virtual async Task<T> GetSingleRowAsync<T>(string commandText, CommandType commandType, BuildDataObject<T> buildObject, IList<IDbDataParameter> parameters = null)
        {
            parameters = parameters ?? new List<IDbDataParameter>();

            try
            {
                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                return buildObject(reader);
                            }
                        }
                    }
                }

                return default(T);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Queries the database and builds a datatable of the results
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A DataTable from the results of the query</returns>
        public virtual DataTable GetDataTable(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null)
        {
            try
            {
                parameters = parameters ?? new List<IDbDataParameter>();
                var retVal = new DataTable();

                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = command.ExecuteReader())
                        {
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                var name = reader.GetName(i);

                                if (!retVal.Columns.Contains(name))
                                    retVal.Columns.Add(new DataColumn(name, reader.GetReaderDataType(i, typeof(string))));
                                else
                                    retVal.Columns.Add(new DataColumn(string.Format("{0}_{1}", name, i.ToString()), reader.GetReaderDataType(i, typeof(string))));
                            }

                            while (reader.Read())
                            {
                                var row = retVal.NewRow();

                                for (var i = 0; i < reader.FieldCount; i++)
                                {
                                    row[i] = reader[i];
                                }

                                retVal.Rows.Add(row);
                            }
                        }
                    }
                }

                return retVal;
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }

        /// <summary>
        /// Queries the database and builds a datatable of the results asynchronously
        /// </summary>
        /// <param name="commandText">The query or stored procedure to run</param>
        /// <param name="commandType">The type of command, text, or stored proc to run</param>
        /// <param name="parameters">Optional list of parameters to use in the query</param>
        /// <returns>A DataTable from the results of the query</returns>
        public virtual async Task<DataTable> GetDataTableAsync(string commandText, CommandType commandType, IList<IDbDataParameter> parameters = null)
        {
            try
            {
                parameters = parameters ?? new List<IDbDataParameter>();
                var retVal = new DataTable();

                using (var connection = ProviderFactory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new IpDataAccessException("Could not connect to the database");
                    }

                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = QueryTimeout == 0 ? 120 : QueryTimeout;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                var name = reader.GetName(i);

                                if (!retVal.Columns.Contains(name))
                                    retVal.Columns.Add(new DataColumn(name, reader.GetReaderDataType(i, typeof(string))));
                                else
                                    retVal.Columns.Add(new DataColumn(string.Format("{0}_{1}", name, i.ToString()), reader.GetReaderDataType(i, typeof(string))));
                            }

                            while (await reader.ReadAsync())
                            {
                                var row = retVal.NewRow();

                                for (var i = 0; i < reader.FieldCount; i++)
                                {
                                    row[i] = reader[i];
                                }

                                retVal.Rows.Add(row);
                            }
                        }
                    }
                }

                return retVal;
            }
            catch (Exception ex)
            {
                throw new IpDataAccessException(string.Format("SQL {0}: {1} failed to execute, see inner exception for more details.",
                    commandType == CommandType.StoredProcedure ? "Stored Proc" : "Text", commandText), ex);
            }
        }
    }
}
