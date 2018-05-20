using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Ip.Sdk.DataAccess.AdoDataLayers
{
    /// <summary>
    /// Implementation of the IIpMsSql interface
    /// </summary>
    internal class IpMsSqlParameter : IIpMsSqlParameter
    {
        /// <summary>
        /// The underlying data parameter we plan on using
        /// </summary>
        public SqlParameter DataParameter { get; private set; }

        /// <summary>
        /// A database type specific to MS SQL Server
        /// </summary>
        public SqlDbType DataType { get; set; }

        /// <summary>
        /// The direction, input, output, of the parameter
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// The name of the parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precision of a numeric parameter
        /// </summary>
        public byte Precision { get; set; }

        /// <summary>
        /// The Scale of a numeric parameter
        /// </summary>
        public byte Scale { get; set; }

        /// <summary>
        /// The Size of the parameter
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the name of the source column that is mapped to the DataSet and used for loading or returning the IDataParameter.Value
        /// </summary>
        public string SourceColumn { get; set; }

        /// <summary>
        /// Gets or sets the DataRowVersion to use when loading IDataParameter.Value
        /// </summary>
        public DataRowVersion SourceVersion { get; set; }

        /// <summary>
        /// The value of the parameter
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Creates the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        public void CreateParameter(string name, object value, bool isNullable = false)
        {
            DataParameter = new SqlParameter
            {
                ParameterName = name,
                Value = isNullable && value == null ? DBNull.Value : value
            };
        }

        /// <summary>
        /// Creates the DB Parameter of the specified type
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of type K</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        public void CreateParameter(string name, object value, SqlDbType dbType, bool isNullable = false)
        {
            DataParameter = new SqlParameter
            {
                ParameterName = name,
                Value = isNullable && value == null ? DBNull.Value : value,
                SqlDbType = dbType
            };
        }

        /// <summary>
        /// Creates the DB Parameter of the specified type
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of type K</param>
        /// <param name="direction">The input, output direction of the parameter</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        public void CreateParameter(string name, object value, SqlDbType dbType, ParameterDirection direction, bool isNullable = false)
        {
            DataParameter = new SqlParameter
            {
                ParameterName = name,
                Value = isNullable && value == null ? DBNull.Value : value,
                SqlDbType = dbType,
                Direction = direction
            };
        }
    }
}
