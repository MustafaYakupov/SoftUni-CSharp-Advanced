using System;
using System.Collections.Generic;
using System.Linq;

namespace p04Largest3Numbers
{
    class p04Largest3Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
           
            Console.WriteLine(string.Join(" ", numbers.OrderByDescending(x => x).Take(3)));
        }
    }
}
