using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Factories
{
    /// <summary>
    /// Factory for db params
    /// </summary>
    public class IpDataParameterFactory
    {
        private IList<IDbDataParameter> _parameters;

        /// <summary>
        /// The collection of IDbDataParameters
        /// </summary>
        public IList<IDbDataParameter> Parameters
        {
            get { return _parameters = (_parameters ?? new List<IDbDataParameter>()); }
        }

        /// <summary>
        /// Method to add a pre-build database parameter. Use this when doing custom parameters or specialized for a certain type of database such as SQL Structured Parameters
        /// </summary>
        /// <param name="parameter">The parameter to add to the collection</param>
        public void AddParameter(IDbDataParameter parameter)
        {
            _parameters.Add(parameter);
        }

        #region MySql Params
        /// <summary>
        /// Creates and adds the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="parameter">Optionally injectible parameter object</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        public void AddParameter(string name, object value, IIpMySqlParameter parameter, bool isNullable = false)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (!isNullable && value == null)
            {
                throw new IpDataAccessParameterException(string.Format("Non-nullable parameter: {0} is null.", name));
            }
            #endregion

            try
            {
                parameter = parameter ?? new IpMySqlParameter();
                parameter.CreateParameter(name, value, isNullable);

                Parameters.Add(parameter.DataParameter);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessParameterException("An error occured creating the parameter", ex);
            }
        }

        /// <summary>
        /// Creates and adds the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of the parameter</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        /// <param name="parameter">Optionally injectible parameter object</param>
        public void AddParameter(string name, object value, MySqlDbType dbType, bool isNullable = false, IIpMySqlParameter parameter = null)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (!isNullable && value == null)
            {
                throw new IpDataAccessParameterException(string.Format("Non-nullable parameter: {0} is null.", name));
            }
            #endregion

            try
            {
                parameter = parameter ?? new IpMySqlParameter();
                parameter.CreateParameter(name, value, dbType, isNullable);

                Parameters.Add(parameter.DataParameter);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessParameterException("An error occured creating the parameter", ex);
            }
        }

        /// <summary>
        /// Creates and adds the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of the parameter</param>
        /// <param name="direction">The input, output direction of the parameter</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        /// <param name="parameter">Optionally injectible parameter object</param>
        public void AddParameter(string name, object value, MySqlDbType dbType, ParameterDirection direction, bool isNullable = false, IIpMySqlParameter parameter = null)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (!isNullable && value == null)
            {
                throw new IpDataAccessParameterException(string.Format("Non-nullable parameter: {0} is null.", name));
            }
            #endregion

            try
            {
                parameter = parameter ?? new IpMySqlParameter();
                parameter.CreateParameter(name, value, dbType, direction, isNullable);

                Parameters.Add(parameter.DataParameter);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessParameterException("An error occured creating the parameter", ex);
            }
        }
        #endregion

        #region MS SQL Params
        /// <summary>
        /// Creates and adds the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="parameter">Optionally injectible parameter object</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        public void AddParameter(string name, object value, IIpMsSqlParameter parameter, bool isNullable = false)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (!isNullable && value == null)
            {
                throw new IpDataAccessParameterException(string.Format("Non-nullable parameter: {0} is null.", name));
            }
            #endregion

            try
            {
                parameter = parameter ?? new IpMsSqlParameter();
                parameter.CreateParameter(name, value, isNullable);

                Parameters.Add(parameter.DataParameter);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessParameterException("An error occured creating the parameter", ex);
            }
        }    

        /// <summary>
        /// Creates and adds the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of the parameter</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        /// <param name="parameter">Optionally injectible parameter object</param>
        public void AddParameter(string name, object value, SqlDbType dbType, bool isNullable = false, IIpMsSqlParameter parameter = null)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (!isNullable && value == null)
            {
                throw new IpDataAccessParameterException(string.Format("Non-nullable parameter: {0} is null.", name));
            }
            #endregion

            try
            {
                parameter = parameter ?? new IpMsSqlParameter();
                parameter.CreateParameter(name, value, dbType, isNullable);

                Parameters.Add(parameter.DataParameter);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessParameterException("An error occured creating the parameter", ex);
            }
        }

        /// <summary>
        /// Creates and adds the DB Parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <param name="dbType">The data type of the parameter</param>
        /// <param name="direction">The input, output direction of the parameter</param>
        /// <param name="isNullable">Optional parameter indicating if the value is nullable to set the DBNull object, defaults to false</param>
        /// <param name="parameter">Optionally injectible parameter object</param>
        public void AddParameter(string name, object value, SqlDbType dbType, ParameterDirection direction, bool isNullable = false, IIpMsSqlParameter parameter = null)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (!isNullable && value == null)
            {
                throw new IpDataAccessParameterException(string.Format("Non-nullable parameter: {0} is null.", name));
            }
            #endregion

            try
            {
                parameter = parameter ?? new IpMsSqlParameter();
                parameter.CreateParameter(name, value, dbType, direction, isNullable);

                Parameters.Add(parameter.DataParameter);
            }
            catch (Exception ex)
            {
                throw new IpDataAccessParameterException("An error occured creating the parameter", ex);
            }
        }
        #endregion
    }
}
