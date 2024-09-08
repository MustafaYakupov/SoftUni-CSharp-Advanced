using System;
using System.Linq;

namespace p04SortNumbers
{
    class p04SortNumbers
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();

            arr.Sort();

            Console.WriteLine(string.Join(" <= ", arr));
        }
    }
}