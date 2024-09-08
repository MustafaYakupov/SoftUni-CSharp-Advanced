using System;
using System.Collections.Generic;
using System.Linq;

namespace p05SortNumbers
{
    class p05SortNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            numbers.Sort();

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}
