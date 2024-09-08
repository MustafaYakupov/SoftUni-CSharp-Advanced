using System;
using System.Collections.Generic;
using System.Linq;

namespace p03SumMinMaxAverage
{
    class p03SumMinMaxAverage
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] numbers = new int[num];

            for (int i = 0; i < num; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Sum = {numbers.Sum()}");
            Console.WriteLine($"Min = {numbers.Min()}");
            Console.WriteLine($"Max = {numbers.Max()}");
            Console.WriteLine($"Average = {numbers.Average()}");
        }
    }
}
