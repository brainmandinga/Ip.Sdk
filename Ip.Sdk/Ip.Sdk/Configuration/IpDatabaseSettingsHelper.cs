using Ip.Sdk.Commons.Arguments.Interfaces;
using Ip.Sdk.Configuration.Interfaces;
using Ip.Sdk.DataAccess.AdoDataLayers.Interfaces;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using System.Collections.Generic;
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
        public override object GetSetting(IList<IIpArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args);

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var commandText = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtext", System.StringComparison.OrdinalIgnoreCase));
            var commandType = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtype", System.StringComparison.OrdinalIgnoreCase));
            var parameters = args.FirstOrDefault(a => a.ArgumentKey.Equals("parameters", System.StringComparison.OrdinalIgnoreCase));

            return _dataLayer.GetScalar<object>(commandText.ArgumentValue, commandType.ArgumentValue, parameters.ArgumentValue);
        }

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public override void SaveSetting(IList<IIpArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args);

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var commandText = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtext", System.StringComparison.OrdinalIgnoreCase));
            var commandType = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtype", System.StringComparison.OrdinalIgnoreCase));
            var parameters = args.FirstOrDefault(a => a.ArgumentKey.Equals("parameters", System.StringComparison.OrdinalIgnoreCase));

            _dataLayer.ExecuteNonQuery(commandText.ArgumentValue, commandType.ArgumentValue, parameters.ArgumentValue);
        }

        /// <summary>
        /// Deletes a setting by Id
        /// </summary>
        /// <param name="args">A collection of arguments for the settings</param>
        public override void DeleteSetting(IList<IIpArgument> args)
        {
            #region Validations
            var exceptions = ValidateSettingsArgs(args);

            if (exceptions.Any())
            {
                throw new IpSettingException(string.Join(" | ", exceptions));
            }
            #endregion

            var commandText = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtext", System.StringComparison.OrdinalIgnoreCase));
            var commandType = args.FirstOrDefault(a => a.ArgumentKey.Equals("commandtype", System.StringComparison.OrdinalIgnoreCase));
            var parameters = args.FirstOrDefault(a => a.ArgumentKey.Equals("parameters", System.StringComparison.OrdinalIgnoreCase));

            _dataLayer.ExecuteNonQuery(commandText.ArgumentValue, commandType.ArgumentValue, parameters.ArgumentValue);
        }
    }
}
