using System;
using System.Linq;
using System.Numerics;

namespace p06Heists
{
    class p06Heists
    {
        static void Main(string[] args)
        {
            long[] prices = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long jewelsPrice = prices[0];
            long goldPrice = prices[1];

            long jewelsCount = 0;
            long goldCount = 0;
            long totalExpenses = 0;


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Jail Time")
                {
                    break;
                }

                var heist = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string loot = heist[0];
                long expenses = long.Parse(heist[1]);
                totalExpenses += expenses;

                foreach (var ch in loot)
                {
                    if (ch == '%')
                    {
                        jewelsCount++;
                    }
                    if (ch == '$')
                    {
                        goldCount++;
                    }
                }
            }

            BigInteger earnings = (jewelsCount * jewelsPrice) + (goldCount * goldPrice);
            BigInteger totalEarnings = earnings - totalExpenses;
            BigInteger lost = totalExpenses - earnings;

           

            if (earnings >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarnings}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {lost}.");
            }
        }
    }
}
