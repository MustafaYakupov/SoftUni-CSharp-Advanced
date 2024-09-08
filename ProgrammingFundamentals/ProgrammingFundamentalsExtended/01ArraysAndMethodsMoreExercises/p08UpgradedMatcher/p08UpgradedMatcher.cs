using System;
using System.Collections.Generic;
using System.Linq;

namespace p08UpgradedMatcher
{
    class p08UpgradedMatcher
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<long> quantities = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<decimal> prices = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "done")
                {
                    break;
                }

                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string product = tokens[0];
                long quantity = long.Parse(tokens[1]);
                
                int index = products.IndexOf(product);

                if (quantities.Count < index + 1)
                {
                    Console.WriteLine($"We do not have enough {products[index]}");
                }
                else if (quantities[index] < quantity)
                {
                    Console.WriteLine($"We do not have enough {products[index]}");
                }
                else
                {
                Console.WriteLine($"{product} x {quantity} costs {(prices[index] * quantity):f2}");
                quantities[index] -= quantity;
                }

            }
        }
    }
}
