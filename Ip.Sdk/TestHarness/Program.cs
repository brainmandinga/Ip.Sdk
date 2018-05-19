using Ip.Sdk.Security.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
