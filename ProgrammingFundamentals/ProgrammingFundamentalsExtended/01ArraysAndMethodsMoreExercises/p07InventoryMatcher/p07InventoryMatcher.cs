using System;
using System.Collections.Generic;
using System.Linq;

namespace p07InventoryMatcher
{
    class p07InventoryMatcher
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).ToList();
            List<long> quantities = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<decimal> prices = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();

            while (true)
            {
                string productName = Console.ReadLine();

                if (productName == "done")
                {
                    break;
                }

                int index = products.IndexOf(productName);

                Console.WriteLine($"{productName} costs: {prices[index]}; Available quantity: {quantities[index]}");
            }
        }
    }
}
