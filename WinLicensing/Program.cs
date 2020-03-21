using Ink;
using Microsoft.Win32;
using NStandard;
using System;
using System.Linq;

namespace WinLicensing
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\ProductOptions", "ProductPolicy", null) as byte[];
            var policy = new ProductPolicy(bytes);
            var values = policy.Values.Where(x => x.Key.Contains("InBoxGames"));

            Echo.BorderTable(new[] { "Key", "Value" }, values.Select(v => new[]
            {
                v.Key,
                v.Value.Select(x => x.ToString("x2") + " ").Join(""),
            }).ToArray(), new[] { 48, 24 });

            Console.ReadLine();
        }
    }
}
