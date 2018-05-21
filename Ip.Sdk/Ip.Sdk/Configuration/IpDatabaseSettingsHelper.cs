﻿using Ip.Sdk.Configuration.Interfaces;
using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ip.Sdk.Configuration
{
    /// <summary>
    /// Helper class for getting and saving settings to the database
    /// </summary>
    internal class IpDatabaseSettingsHelper : IpBaseSettingsHelper, IIpDatabaseSettingsHelper
    {
        private IIpBaseDataLayer _dataLayer;

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="dataLayer">The data layer to use</param>
        public IpDatabaseSettingsHelper(IIpBaseDataLayer dataLayer)
        {
            _dataLayer = dataLayer ?? throw new IpSettingException("The data layer provided to the database settings helper cannot be null");
        }

        /// <summary>
        /// Gets a scalar setting by its Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        /// <returns>An object of type T</returns>
        public override object GetSetting(IList<IIpSettingArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args, new List<string> { "commandText", "commandType" });

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var commandText = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtext", System.StringComparison.OrdinalIgnoreCase));
            var commandType = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtype", System.StringComparison.OrdinalIgnoreCase));
            var parameters = args.FirstOrDefault(a => a.ArgumentKey.Equals("parameters", System.StringComparison.OrdinalIgnoreCase));

            #region Additional Validations
            if (!commandText.ArgumentValue is string || string.IsNullOrWhiteSpace(commandText.ArgumentValue))
            {
                throw new IpSettingException("Command Text is not valid for GetSetting");
            }

            if (!commandType.ArgumentValue is CommandType)
            {
                throw new IpSettingException("Command Type is not valid for GetSetting");
            }

            if (!parameters.ArgumentValue is IList<IDbDataParameter>)
            {
                throw new IpSettingException("The Parameters is not a List of IDbDataParameters for GetSetting");
            }
            #endregion

            return _dataLayer.GetScalar<object>(commandText.ArgumentValue, commandType.ArgumentValue, parameters.ArgumentValue);
        }

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public override void SaveSetting(IList<IIpSettingArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args, new List<string> { "commandText", "commandType" });

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var commandText = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtext", System.StringComparison.OrdinalIgnoreCase));
            var commandType = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtype", System.StringComparison.OrdinalIgnoreCase));
            var parameters = args.FirstOrDefault(a => a.ArgumentKey.Equals("parameters", System.StringComparison.OrdinalIgnoreCase));

            #region Additional Validations
            if (!commandText.ArgumentValue is string || string.IsNullOrWhiteSpace(commandText.ArgumentValue))
            {
                throw new IpSettingException("Command Text is not valid for GetSetting");
            }

            if (!commandType.ArgumentValue is CommandType)
            {
                throw new IpSettingException("Command Type is not valid for GetSetting");
            }

            if (!parameters.ArgumentValue is IList<IDbDataParameter>)
            {
                throw new IpSettingException("The Parameters is not a List of IDbDataParameters for GetSetting");
            }
            #endregion

            _dataLayer.ExecuteNonQuery(commandText.ArgumentValue, commandType.ArgumentValue, parameters.ArgumentValue);
        }

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public override void DeleteSetting(IList<IIpSettingArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args, new List<string> { "commandText", "commandType" });

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var commandText = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtext", System.StringComparison.OrdinalIgnoreCase));
            var commandType = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtype", System.StringComparison.OrdinalIgnoreCase));
            var parameters = args.FirstOrDefault(a => a.ArgumentKey.Equals("parameters", System.StringComparison.OrdinalIgnoreCase));

            #region Additional Validations
            if (!commandText.ArgumentValue is string || string.IsNullOrWhiteSpace(commandText.ArgumentValue))
            {
                throw new IpSettingException("Command Text is not valid for GetSetting");
            }

            if (!commandType.ArgumentValue is CommandType)
            {
                throw new IpSettingException("Command Type is not valid for GetSetting");
            }

            if (!parameters.ArgumentValue is IList<IDbDataParameter>)
            {
                throw new IpSettingException("The Parameters is not a List of IDbDataParameters for GetSetting");
            }
            #endregion

            _dataLayer.ExecuteNonQuery(commandText.ArgumentValue, commandType.ArgumentValue, parameters.ArgumentValue);
        }
    }
}
