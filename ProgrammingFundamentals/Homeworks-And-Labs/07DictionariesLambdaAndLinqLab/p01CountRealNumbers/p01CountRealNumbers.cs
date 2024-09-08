using System;
using System.Collections.Generic;
using System.Linq;

namespace p01CountRealNumbers
{
    class p01CountRealNumbers
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var count = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!count.ContainsKey(num))
                {
                    count[num] = 1;
                }
                else
                {
                    count[num]++;
                }
            }
            foreach (var num in count)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
