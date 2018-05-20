using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;

namespace Ip.Sdk.DataAccess.AdoDataLayers.Factories
{
    /// <summary>
    /// Factory for handling data access
    /// </summary>
    public class IpDataAccessFactory
    {
        /// <summary>
        /// Gets the datalayer using the connection string from the config file
        /// </summary>
        /// <param name="connectionStringName">The connection string name</param>
        /// <param name="useDefault">If not provided, should it use the default provider name</param>
        /// <returns>An instantiated data layer of the provider type from the connection string</returns>
        public virtual IIpBaseDataLayer GetDataLayer(string connectionStringName, bool useDefault = false)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new IpDataLayerException(string.Format("The provided connection string name: {0} is not a valid value.", connectionStringName == null ? "null" : "empty"));
            }
            #endregion

            var connString = ConfigurationHelper.GetConnectionString(connectionStringName);
            return GetDataLayerByProvider(connString.ConnectionString, connString.ProviderName, useDefault);
        }

        /// <summary>
        /// Gets the datalayer from the database provider
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="providerName">The provider name</param>
        /// <param name="useDefault">If not provided, should it use the default provider name</param>
        /// <returns>An instantiated data layer of the provider type</returns>
        public IIpBaseDataLayer GetDataLayerByProvider(string connectionString, string providerName, bool useDefault = false)
        {         
            if (string.IsNullOrWhiteSpace(providerName) && useDefault)
            {
                var defaultProvider = ConfigurationHelper.GetSystemSetting<string>("DefaultDatabaseProvider");
                providerName = defaultProvider;
            }

            if (providerName.Equals("MySql.Data.MySqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return GetDataLayer(connectionString, (IpMySqlDataLayer)null);
            }

            if (providerName.Equals("System.Data.SqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return GetDataLayer(connectionString, (IpMsSqlDataLayer)null);
            }

            return GetExtendedDataLayerByProvider(connectionString, providerName);
        }

        /// <summary>
        /// An extensible method for getting other ADO based data layers that are implemented in derived classes
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="providerName">The provider name to use</param>
        /// <returns>When overriden and implemented it will return a datalayer of the type from the provider name</returns>
        public virtual IIpBaseDataLayer GetExtendedDataLayerByProvider(string connectionString, string providerName)
        {
            throw new IpDataLayerException(string.Format("The provider: {0} was not found in the main factory method or the extended.", providerName));
        }  
        
        /// <summary>
        /// Gets a MySQL Data Layer
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="dataLayer">Optionally injectible data layer</param>
        /// <returns>A newly instantiated MySql Data Layer</returns>
        public IIpBaseDataLayer GetDataLayer(string connectionString, IIpMySqlDataLayer dataLayer)
        {
            return dataLayer ?? new IpMySqlDataLayer(connectionString);
        }

        /// <summary>
        /// Gets a MySQL Data Layer
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="dataLayer">Optionally injectible data layer</param>
        /// <returns>A newly instantiated MySql Data Layer</returns>
        public IIpBaseDataLayer GetDataLayer(string connectionString, IIpMsSqlDataLayer dataLayer)
        {
            return dataLayer ?? new IpMsSqlDataLayer(connectionString);
        }
    }
}
