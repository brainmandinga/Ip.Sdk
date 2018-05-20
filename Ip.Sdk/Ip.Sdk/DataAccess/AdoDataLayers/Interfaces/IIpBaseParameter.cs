using System.Data;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Interfaces
{
    /// <summary>
    /// Base Parameter Interface
    /// </summary>
    public interface IIpBaseParameter<T,K> where T : IDbDataParameter
    {
        /// <summary>
        /// The underlying data parameter we plan on using
        /// </summary>
        T DataParameter { get; }
        
        /// <summary>
        /// The Data Type of the parameter
        /// </summary>
        K DataType { get; set; }

        /// <summary>
        /// The direction, input, output, of the parameter
        /// </summary>
        ParameterDirection Direction { get; set; }

        /// <summary>
        /// The name of the parameter
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The precision of a numeric parameter
        /// </summary>
        byte Precision { get; set; }

        /// <summary>
        /// The Scale of a numeric parameter
        /// </summary>
        byte Scale { get; set; }

        /// <summary>
        /// The Size of the parameter
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Gets or sets the name of the source column that is mapped to the DataSet and used for loading or returning the IDataParameter.Value
        /// </summary>
        string SourceColumn { get; set; }

        /// <summary>
        /// Gets or sets the DataRowVersion to use when loading IDataParameter.Value
        /// </summary>
        DataRowVersion SourceVersion { get; set; }

        /// <summary>
        /// The value of the parameter
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Creates the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        void CreateParameter(string name, object value, bool isNullable = false);

        /// <summary>
        /// Creates the DB Parameter of the specified type
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of type K</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        void CreateParameter(string name, object value, K dbType, bool isNullable = false);

        /// <summary>
        /// Creates the DB Parameter of the specified type
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of type K</param>
        /// <param name="direction">The input, output direction of the parameter</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        void CreateParameter(string name, object value, K dbType, ParameterDirection direction, bool isNullable = false);
    }
}
