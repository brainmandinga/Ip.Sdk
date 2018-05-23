using Ip.Sdk.Commons.Validators;
using Ip.Sdk.Commons.Validators.Interfaces;
using Ip.Sdk.Configuration.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Ip.Sdk.Configuration
{
    /// <summary>
    /// Class for a setting argument for crud operations
    /// </summary>
    public class IpSettingArgument : IIpSettingArgument
    {
        private IList<IIpValidator> _keyValidators;
        private IList<IIpValidator> _valueValidators;

        /// <summary>
        /// The key for the arguments
        /// </summary>
        public string ArgumentKey { get; set; }

        /// <summary>
        /// A dynamic value
        /// </summary>
        public dynamic ArgumentValue { get; set; }

        /// <summary>
        /// Validators for the Keys
        /// </summary>
        public IList<IIpValidator> KeyValidators
        {
            get { return _keyValidators = (_keyValidators ?? new List<IIpValidator>()); }
            set { _keyValidators = value; }
        }

        /// <summary>
        /// Validators for the values
        /// </summary>
        public IList<IIpValidator> ValueValidators
        {
            get { return _valueValidators = (_valueValidators ?? new List<IIpValidator>()); }
            set { _valueValidators = value; }
        }

        /// <summary>
        /// Validates the Settings Argument using the Validators set on this object
        /// </summary>
        /// <returns>A Validation Result Argument</returns>
        public IList<IpValidationResult> Validate()
        {
            return Validate(KeyValidators, ValueValidators);
        }

        /// <summary>
        /// Validates the Settings Argument
        /// </summary>
        /// <param name="keyValidators">The validators for the keys</param>
        /// <param name="valueValidators">The validators for the values</param>
        /// <returns>A Validation Result Argument</returns>
        public IList<IpValidationResult> Validate(IList<IIpValidator> keyValidators, IList<IIpValidator> valueValidators)
        {
            var retVal = new List<IpValidationResult>();

            foreach (var kv in keyValidators)
            {
                retVal.Add(kv.Validate());
            }

            foreach (var vv in valueValidators)
            {
                retVal.Add(vv.Validate());
            }

            return retVal;
        }

        /// <summary>
        /// Static Method to Get Common App Settings Arg
        /// </summary>
        /// <returns>An App Settings Arg</returns>
        public static IpSettingArgument GetStandardAppSettingArg()
        {
            var retVal = new IpSettingArgument { ArgumentKey = "ConfigSection", ArgumentValue = "appSettings" };

            retVal.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentKey),
                new IpStringValueValidator(retVal.ArgumentKey, "ConfigSection")
            };

            retVal.ValueValidators = new List<IIpValidator>
            {
                new IpStringValueValidator(retVal.ArgumentValue, "appSettings")
            };

            return retVal;
        }

        /// <summary>
        /// Static Method to Get Common Connection String Arg
        /// </summary>
        /// <returns>A Connection String Arg</returns>
        public static IpSettingArgument GetStandardConnectionStringArg()
        {
            var retVal = new IpSettingArgument { ArgumentKey = "ConfigSection", ArgumentValue = "connectionStrings" };

            retVal.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentKey),
                new IpStringValueValidator(retVal.ArgumentKey, "ConfigSection")
            };

            retVal.ValueValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentKey),
                new IpStringValueValidator(retVal.ArgumentValue, "connectionStrings")
            };

            return retVal;
        }

        /// <summary>
        /// Static Method to Get Common Setting Id Arg
        /// </summary>
        /// <param name="value">The Value for the Setting Id</param>
        /// <returns>A Setting Id Arg</returns>
        public static IpSettingArgument GetStandardSettingIdArg(string value)
        {
            var retVal = new IpSettingArgument { ArgumentKey = "SettingId", ArgumentValue = value };

            retVal.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentKey),
                new IpStringValueValidator(retVal.ArgumentKey, "SettingId")
            };

            retVal.ValueValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentValue)
            };

            return retVal;
        }

        /// <summary>
        /// Static Method to Get Common Setting Value Arg
        /// </summary>
        /// <param name="value">The Value for the Setting Value</param>
        /// <returns>A Setting Value Arg</returns>
        public static IpSettingArgument GetStandardSettingValueArg(string value)
        {
            var retVal = new IpSettingArgument { ArgumentKey = "SettingValue", ArgumentValue = value };

            retVal.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentKey),
                new IpStringValueValidator(retVal.ArgumentKey, "SettingValue")
            };

            retVal.ValueValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(retVal.ArgumentValue)
            };

            return retVal;
        }

        /// <summary>
        /// Static Method to build setting arguments to get a setting from the configuration
        /// </summary>
        /// <param name="settingName">The name of the setting</param>
        /// <returns>A predefined set of args</returns>
        public static IList<IIpSettingArgument> GetConfigAppSetting(string settingName)
        {
            return new List<IIpSettingArgument>
            {
                GetStandardAppSettingArg(),
                GetStandardSettingIdArg(settingName)
            };
        }

        /// <summary>
        /// Static Method to build setting arguments to get a connectionString from the configuration
        /// </summary>
        /// <param name="connStringName">The name of the connection string</param>
        /// <returns>A predefined set of args</returns>
        public static IList<IIpSettingArgument> GetConfigConnString(string connStringName)
        {
            return new List<IIpSettingArgument>
            {
                GetStandardConnectionStringArg(),
                GetStandardSettingIdArg(connStringName)
            };
        }

        /// <summary>
        /// Static method to build setting arguments for a database setting helper
        /// </summary>
        /// <param name="commandText">The query or stored proc</param>
        /// <param name="commandType">If it's a query or stored proc</param>
        /// <param name="parameters">Parameters, if any</param>
        /// <returns>A predefined set of args</returns>
        public static IList<IIpSettingArgument> GetDatabaseArg(string commandText, CommandType commandType, IList<IDbDataParameter> parameters)
        {
            var retVal = new List<IIpSettingArgument>();
            var queryArg = new IpSettingArgument { ArgumentKey = "commandText", ArgumentValue = commandText };

            queryArg.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(queryArg.ArgumentKey),
                new IpStringValueValidator(queryArg.ArgumentKey, "commandText")
            };

            queryArg.ValueValidators = new List<IIpValidator>
            {
                new IpTypeValidator<string>(queryArg.ArgumentValue),
                new IpRequiredStringValidator(queryArg.ArgumentValue)
            };

            var typeArg = new IpSettingArgument { ArgumentKey = "commandType", ArgumentValue = commandType };

            typeArg.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(typeArg.ArgumentKey),
                new IpStringValueValidator(typeArg.ArgumentKey, "commandType")
            };

            typeArg.ValueValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(queryArg.ArgumentValue),
                new IpTypeValidator<CommandType>(queryArg.ArgumentValue)
            };

            var paramArg = new IpSettingArgument { ArgumentKey = "parameters", ArgumentValue = parameters };

            paramArg.KeyValidators = new List<IIpValidator>
            {
                new IpRequiredStringValidator(typeArg.ArgumentKey),
                new IpStringValueValidator(typeArg.ArgumentKey, "parameters")
            };

            paramArg.ValueValidators = new List<IIpValidator>
            {
                new IpTypeValidator<IList<IDbDataParameter>>(paramArg.ArgumentValue)
            };

            retVal.Add(queryArg);
            retVal.Add(typeArg);
            retVal.Add(paramArg);

            return retVal;
        }
    }
}
