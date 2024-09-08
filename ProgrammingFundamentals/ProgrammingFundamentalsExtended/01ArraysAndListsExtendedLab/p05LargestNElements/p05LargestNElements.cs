using System;
using System.Collections.Generic;
using System.Linq;

namespace p05LargestNElements
{
    class p05LargestNElements
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int number =int.Parse(Console.ReadLine());

            arr = arr.OrderByDescending(s => s).ToList();
            arr = arr.Take(number).ToList();

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
