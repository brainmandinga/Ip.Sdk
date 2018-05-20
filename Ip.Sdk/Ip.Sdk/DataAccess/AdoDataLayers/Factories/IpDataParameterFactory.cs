using Ip.Sdk.ErrorHandling.CustomExceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Factories
{
    public class IpDataParameterFactory
    {
        private IList<IDbDataParameter> _parameters;

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

        /// <summary>
        /// Adds a parameter to the Parameters collection
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="parameterType">The data type of the parameter</param>
        /// <param name="dataLayer">The data layer to look for implementations</param>
        public virtual void AddParameter(string name, object value, DbType parameterType, IpBaseDataLayer dataLayer)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (dataLayer == null)
            {
                throw new IpDataAccessParameterException("The data layer used is null");
            }
            #endregion

            AddParameter(CreateParameterByProvider(dataLayer, dataLayer.DatabaseProvider), name, value, parameterType);            
        }        

        /// <summary>
        /// Adds a parameter to the Parameters collection
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="parameterType">The data type of the parameter</param>
        /// <param name="dataLayer">The data layer to look for implementations</param>
        /// <param name="provider">The database provider</param>
        public virtual void AddParameterByProvider(string name, object value, DbType parameterType, IpBaseDataLayer dataLayer, string provider)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (dataLayer == null)
            {
                throw new IpDataAccessParameterException("The data layer used is null");
            }

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new IpDataAccessParameterException(string.Format("The database provider: {0} is null or empty", provider == null ? "null" : "empty"));
            }
            #endregion

            AddParameter(CreateParameterByProvider(dataLayer, provider), name, value, parameterType);
        }

        /// <summary>
        /// Adds a parameter to the Parameters collection
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="parameterType">The data type of the parameter</param>
        /// <param name="dataLayer">The data layer to look for implementations</param>
        /// <param name="dbType">The type of database</param>
        public virtual void AddParameterByDbType(string name, object value, DbType parameterType, IpBaseDataLayer dataLayer, string dbType)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IpDataAccessParameterException(string.Format("The parameter name: {0} is null or empty", name == null ? "null" : "empty"));
            }

            if (dataLayer == null)
            {
                throw new IpDataAccessParameterException("The data layer used is null");
            }

            if (string.IsNullOrWhiteSpace(dbType))
            {
                throw new IpDataAccessParameterException(string.Format("The database type: {0} is null or empty", dbType == null ? "null" : "empty"));
            }
            #endregion

            AddParameter(CreateParameterByDbType(dataLayer, dbType), name, value, parameterType);
        }

        /// <summary>
        /// Creates a parameter by its database name
        /// </summary>
        /// <param name="dataLayer">The data layer to look for implementations</param>
        /// <param name="databaseType">The database type being used</param>
        /// <returns>A newly instantiated IDbDataParameter</returns>
        public virtual IDbDataParameter CreateParameterByDbType(IpBaseDataLayer dataLayer, string databaseType)
        {
            #region Validations
            if (dataLayer == null)
            {
                throw new IpDataAccessParameterException("The provided data layer is null");
            }

            if (dataLayer.DatabaseType == null)
            {
                throw new IpDataAccessParameterException("The provided data layer's Database Type object is null");
            }

            if (string.IsNullOrWhiteSpace(databaseType))
            {
                throw new IpDataAccessParameterException(string.Format("The database type: {0} was null or empty", databaseType == null ? "null" : "empty"));
            }

            if (dataLayer.DatabaseType == null || !dataLayer.DatabaseType.IpDbTypes.ContainsKey(databaseType))
            {
                throw new IpDataAccessParameterException(string.Format("No data layer implemetnations match the database type: {0}.", databaseType));
            }
            #endregion

            return CreateParameterByProvider(dataLayer, dataLayer.DatabaseType.GetProviderFromIpDatabaseType(databaseType));
        }

        /// <summary>
        /// Creates a parameter by its provider
        /// </summary>
        /// <param name="dataLayer">The data layer to look for implementations</param>
        /// <param name="providerName">The name of the provider</param>
        /// <returns>A newly instantiated IDbDataParameter</returns>
        public virtual IDbDataParameter CreateParameterByProvider(IpBaseDataLayer dataLayer, string providerName)
        {
            #region Validations
            if (dataLayer == null)
            {
                throw new IpDataAccessParameterException("The provided data layer is null");
            }

            if (dataLayer.DatabaseType == null)
            {
                throw new IpDataAccessParameterException("The provided data layer's Database Type object is null");
            }

            if (string.IsNullOrWhiteSpace(providerName))
            {
                throw new IpDataAccessParameterException(string.Format("The provider name: {0} was null or empty", providerName == null ? "null" : "empty"));
            }

            if (dataLayer.DatabaseType == null || !dataLayer.DatabaseType.IpDbTypeProviders.ContainsKey(providerName))
            {
                throw new IpDataAccessParameterException(string.Format("No data layer implemetnations match the provider: {0}.", providerName));
            }
            #endregion

            if (providerName.Equals("System.Data.SqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return new SqlParameter();
            }

            if (providerName.Equals("MySql.Data.MySqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return new MySqlParameter();
            }

            return CreateParameterByProviderExtended(dataLayer, providerName);
        }

        /// <summary>
        /// Overrideable method to create a parameter by its provider from a derived class
        /// </summary>
        /// <param name="dataLayer">The data layer to look for implementations</param>
        /// <param name="providerName">The name of the provider</param>
        /// <returns>A newly instantiated IDbDataParameter</returns>
        public virtual IDbDataParameter CreateParameterByProviderExtended(IpBaseDataLayer dataLayer, string providerName)
        {
            throw new IpDataAccessParameterException(string.Format("No data layer implemetnations match the provider: {0}.", providerName));
        }
        
        private void AddParameter(IDbDataParameter baseParam, string name, object value, DbType parameterType)
        {
            baseParam.ParameterName = name;
            baseParam.Value = value ?? DBNull.Value;
            baseParam.DbType = parameterType;
            _parameters.Add(baseParam);
        }
    }
}
