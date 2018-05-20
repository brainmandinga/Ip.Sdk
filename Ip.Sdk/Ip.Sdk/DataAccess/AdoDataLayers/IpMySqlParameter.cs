using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Ip.Sdk.DataAccess.AdoDataLayers
{
    /// <summary>
    /// Implementation of the IIpMySqlParameter
    /// </summary>
    internal class IpMySqlParameter : IIpMySqlParameter
    {
        /// <summary>
        /// The underlying data parameter we plan on using
        /// </summary>
        public MySqlParameter DataParameter { get; private set; }

        /// <summary>
        /// The data type of the parameter
        /// </summary>
        public MySqlDbType DataType { get; set; }        

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
            DataParameter = new MySqlParameter
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
        public void CreateParameter(string name, object value, MySqlDbType dbType, bool isNullable = false)
        {
            DataParameter = new MySqlParameter
            {
                ParameterName = name,
                Value = isNullable && value == null ? DBNull.Value : value,
                MySqlDbType = dbType
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
        public void CreateParameter(string name, object value, MySqlDbType dbType, ParameterDirection direction, bool isNullable = false)
        {
            DataParameter = new MySqlParameter
            {
                ParameterName = name,
                Value = isNullable && value == null ? DBNull.Value : value,
                MySqlDbType = dbType,
                Direction = direction
            };
        }
    }
}
