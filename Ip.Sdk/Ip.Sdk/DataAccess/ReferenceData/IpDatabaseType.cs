using Ip.Sdk.ErrorHandling.CustomExceptions;
using System.Collections.Generic;

namespace Ip.Sdk.DataAccess.ReferenceData
{
    /// <summary>
    /// Handles working with the database types
    /// </summary>
    public class IpDatabaseType
    {
        private Dictionary<string, string> _dbTypes;
        private Dictionary<string, string> _dbTypeProviders;

        /// <summary>
        /// My SQL Constant
        /// </summary>
        public const string MYSQL = "MySql";

        /// <summary>
        /// MS SQL Constant
        /// </summary>
        public const string MSSQL = "SqlServer";

        /// <summary>
        /// Dictionary lookups by type
        /// </summary>
        public Dictionary<string, string> IpDbTypes
        {
            get { return _dbTypes = (_dbTypes ?? new Dictionary<string, string>()); }
            set { _dbTypes = value; }
        }

        /// <summary>
        /// Dictionary lookups by provider
        /// </summary>
        public Dictionary<string, string> IpDbTypeProviders
        {
            get { return _dbTypeProviders = (_dbTypeProviders ?? new Dictionary<string, string>()); }
            set { _dbTypeProviders = value; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="loadDefaults">Optional parameter to load the defaults</param>
        public IpDatabaseType(bool loadDefaults = false)
        {
            if (loadDefaults)
            {
                LoadDefaultValues();
            }
        }

        /// <summary>
        /// Loads the IpDbTypes, and IpDbTypeProviders dictionaries for forward and reverse lookups
        /// </summary>
        public virtual void LoadDefaultValues()
        {
            AddDbTypeLookups(MYSQL, "MySql.Data.MySqlClient");
            AddDbTypeLookups(MSSQL, "System.Data.SqlClient");
        }

        /// <summary>
        /// Allows the addition of db types and their reverse lookups
        /// </summary>
        /// <param name="dbType">The Key for the DbType</param>
        /// <param name="dbTypeProvider">The provider for the lookup</param>
        public virtual void AddDbTypeLookups(string dbType, string dbTypeProvider)
        {
            #region Validations
            if (IpDbTypes.ContainsKey(dbType))
            {
                throw new IpDatabaseTypeException(string.Format("IpDbTypes lookup already contains the key: {0}", dbType));
            }

            if (IpDbTypeProviders.ContainsKey(dbTypeProvider))
            {
                throw new IpDatabaseTypeException(string.Format("IpDbTypeProviders lookup already contains the key: {0}", dbTypeProvider));
            }
            #endregion

            IpDbTypes.Add(dbType, dbTypeProvider);
            IpDbTypeProviders.Add(dbTypeProvider, dbType);
        }

        /// <summary>
        /// Gets the Database Type from the provider
        /// </summary>
        /// <param name="provider">The provider to use</param>
        /// <returns>A database type</returns>
        public string GetDatabaseTypeFromProvider(string provider)
        {
            #region Validations
            if (!IpDbTypeProviders.ContainsKey(provider) || string.IsNullOrWhiteSpace(IpDbTypeProviders[provider]))
            {
                throw new IpDatabaseTypeException(string.Format("Unable to find a database type for provider: {0}", provider));
            }
            #endregion

            return IpDbTypeProviders[provider];
        }

        /// <summary>
        /// Gets the Database Provider from the Database Type
        /// </summary>
        /// <param name="dbType">The type of database</param>
        /// <returns>A database provider</returns>
        public string GetProviderFromIpDatabaseType(string dbType)
        {
            #region Validations
            if (!IpDbTypes.ContainsKey(dbType) || string.IsNullOrWhiteSpace(IpDbTypes[dbType]))
            {
                throw new IpDatabaseTypeException(string.Format("Unable to find a provider for database type: {0}", dbType));
            }
            #endregion

            return IpDbTypes[dbType];
        }
    }
}
