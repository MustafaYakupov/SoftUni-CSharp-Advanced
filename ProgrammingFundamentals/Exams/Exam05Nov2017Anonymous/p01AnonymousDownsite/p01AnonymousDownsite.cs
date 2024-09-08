using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace p01AnonymousDownsite
{
    class p01AnonymousDownsite
    {
        static void Main(string[] args)
        {
            int websitesDown = int.Parse(Console.ReadLine());
            BigInteger securityKey = BigInteger.Parse(Console.ReadLine());

            decimal totalLosses = 0m;
            var siteNames = new List<string>();
            BigInteger securityToken = 0;

            for (BigInteger i = 0; i < websitesDown; i++)
            {
                string[] website = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = website[0];
                ulong visits = ulong.Parse(website[1]);
                decimal pricePerVisit = decimal.Parse(website[2]);

                decimal siteLoss = visits * pricePerVisit;
                totalLosses += siteLoss;

                securityToken = BigInteger.Pow(securityKey, websitesDown);

                siteNames.Add(name);
            }

            foreach (var site in siteNames)
            {
                Console.WriteLine(site);
            }

            Console.WriteLine($"Total Loss: {totalLosses:F20}");

            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}
