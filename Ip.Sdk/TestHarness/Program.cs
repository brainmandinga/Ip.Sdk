using Ip.Sdk.Commons.Configuration;
using Ip.Sdk.Commons.Configuration.Factories;
using Ip.Sdk.Commons.Configuration.Interfaces;
using System;
using System.Configuration;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var configHelper = new IpSettingsFactory().GetSettingsHelper((IIpConfigurationSettingsHelper)null);
            var connString = (ConnectionStringSettings)configHelper.GetSetting(IpSettingArgument.GetConfigConnString("Connection"));
            var allowCors = configHelper.GetSetting(IpSettingArgument.GetConfigAppSetting("AllowCors"));

            Console.WriteLine(connString.ConnectionString);
            Console.WriteLine(allowCors);
            Console.ReadKey();
        }
    }
}
