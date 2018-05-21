using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.Commons.Configuration.Factories;
using Ip.Sdk.Commons.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace TestHarness
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var configHelper = new IpSettingsFactory().GetSettingsHelper((IIpConfigurationSettingsHelper)null);
            var connString = (ConnectionStringSettings)configHelper.GetSetting("Connection", new List<IIpSettingArgument> { IpSettingArgument.GetStandardConnectionStringArg() });

            Console.WriteLine(connString.ConnectionString);
            Console.ReadKey();
        }
    }
}
