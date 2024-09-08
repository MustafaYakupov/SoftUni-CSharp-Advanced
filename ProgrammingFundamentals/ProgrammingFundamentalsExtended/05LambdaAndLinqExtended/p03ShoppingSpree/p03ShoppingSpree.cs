using System;
using System.Collections.Generic;
using System.Linq;

namespace p03ShoppingSpree
{
    class p03ShoppingSpree
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var productPrice = new Dictionary<string, decimal>();

            while (input[0] != "end")
            {
                if (productPrice.ContainsKey(input[0]) == false)
                {
                    productPrice.Add(input[0], decimal.Parse(input[1]));
                }
                else
                {
                    if (productPrice[input[0]] > decimal.Parse(input[1]))
                    {
                        productPrice[input[0]] = decimal.Parse(input[1]);
                    }
                }
                input = Console.ReadLine().Split(' ').ToArray();
            }

            List<decimal> sum = productPrice.Select(x => x.Value).ToList();
            decimal totalSum = sum.Sum(x => Convert.ToDecimal(x));

            productPrice = productPrice.OrderByDescending(x => x.Value).ThenBy(x => x.Key.Length).ToDictionary(x => x.Key, x => x.Value);

            if (totalSum > budget)
            {
                Console.WriteLine("Need more money... Just buy banichka");
            }
            else
            {
                foreach (var pair in productPrice)
                {
                    Console.WriteLine($"{pair.Key} costs {pair.Value:f2}");
                }
            }
        }
    }
}
