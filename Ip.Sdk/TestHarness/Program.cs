using Ip.Sdk.Api.Models;
using System;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var policy = new IpSecurityPolicy(true);

            Console.WriteLine("Loaded Security Policy");
            Console.ReadKey();
        }
    }
}
