using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.DataAccess.ReferenceData;
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
        /// <returns>An instantiated data layer of the provider type from the connection string</returns>
        public virtual IpBaseDataLayer GetDataLayer(string connectionStringName)
        {
            #region Validations
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new IpDataLayerException(string.Format("The provided connection string name: {0} is not a valid value.", connectionStringName == null ? "null" : "empty"));
            }
            #endregion

            var connString = ConfigurationHelper.GetConnectionString(connectionStringName);
            return GetDataLayerByProvider(connString.ConnectionString, connString.ProviderName);
        }

        /// <summary>
        /// Gets the datalayer from the dbtype string
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="databaseType">The database type name</param>
        /// <param name="dbType">An injectible optional parameter allowing for a custom Database Type class to be used, if not provided, defaults will be used</param>
        /// <param name="useDefaultProvider">Whether to use the default provider or not should no provider be present</param>
        /// <returns>An instantiated datalayer based on the database type name</returns>
        public virtual IpBaseDataLayer GetDataLayerByDbType(string connectionString, string databaseType, IpDatabaseType dbType = null, bool useDefaultProvider = false)
        {
            dbType = dbType ?? new IpDatabaseType(true);
            var provider = dbType.GetProviderFromIpDatabaseType(databaseType);

            return GetDataLayerByProvider(connectionString, provider, useDefaultProvider);
        }

        /// <summary>
        /// Gets the datalayer from the database provider
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="providerName">The provider name</param>
        /// <param name="useDefault">If not provided, should it use the default provider name</param>
        /// <returns>An instantiated data layer of the provider type</returns>
        public virtual IpBaseDataLayer GetDataLayerByProvider(string connectionString, string providerName, bool useDefault = false)
        {         
            if (string.IsNullOrWhiteSpace(providerName) && useDefault)
            {
                var defaultProvider = ConfigurationHelper.GetSystemSetting<string>("DefaultDatabaseProvider");
                providerName = defaultProvider;
            }

            if (providerName.Equals("MySql.Data.MySqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return new IpMySqlDataLayer(connectionString, providerName);
            }

            if (providerName.Equals("System.Data.SqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return new IpMsSqlDataLayer(connectionString, providerName);
            }

            return GetExtendedDataLayerByProvider(connectionString, providerName);
        }

        /// <summary>
        /// An extensible method for getting other ADO based data layers that are implemented in derived classes
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="providerName">The provider name to use</param>
        /// <returns>When overriden and implemented it will return a datalayer of the type from the provider name</returns>
        public virtual IpBaseDataLayer GetExtendedDataLayerByProvider(string connectionString, string providerName)
        {
            throw new IpDataLayerException(string.Format("The provider: {0} was not found in the main factory method or the extended.", providerName));
        }        
    }
}
