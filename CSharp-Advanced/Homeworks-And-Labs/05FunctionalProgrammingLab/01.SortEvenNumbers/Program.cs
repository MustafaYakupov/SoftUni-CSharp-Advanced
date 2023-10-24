using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x=> x % 2 == 0)
                .OrderBy(x=>x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
