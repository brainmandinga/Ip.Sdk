using Ip.Sdk.Configuration;
using Ip.Sdk.Configuration.Factories;
using System;
using System.Configuration;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var configHelper = new IpSettingsFactory().GetSettingsHelper(null);
            var connString = (ConnectionStringSettings)configHelper.GetSetting(IpSettingArgument.GetConfigConnString("Connection"));
            var allowCors = configHelper.GetSetting(IpSettingArgument.GetConfigAppSetting("AllowCors"));

            Console.WriteLine(connString.ConnectionString);
            Console.WriteLine(allowCors);
            Console.ReadKey();
        }
    }
}
