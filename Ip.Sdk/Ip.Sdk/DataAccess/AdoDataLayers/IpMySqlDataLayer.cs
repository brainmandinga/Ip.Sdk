﻿using Ip.Sdk.DataAccess.ReferenceData;

namespace Ip.Sdk.DataAccess.AdoDataLayers
{
    /// <summary>
    /// My SQL Data Layer
    /// </summary>
    public class IpMySqlDataLayer : IpBaseDataLayer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">The Connection String</param>
        /// <param name="provider">The Provider for the connection</param>
        /// <param name="dbType">An optionally injected custom database type. If none is provided a standard database type object will be created with defaults</param>
        public IpMySqlDataLayer(string connectionString, string provider, IpDatabaseType dbType = null)
            : base(connectionString, provider, dbType) { }
    }
}
