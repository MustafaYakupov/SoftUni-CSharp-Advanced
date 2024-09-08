using System;
using System.Collections.Generic;
using System.Linq;

namespace p01SortTimes
{
    class p01SortTimes
    {
        static void Main(string[] args)
        {
            var timeList = Console.ReadLine()
                 .Split(' ')
                 .OrderBy(t => t)
                 .ToList();
            Console.WriteLine(string.Join(", ", timeList));
        }
    }
}
