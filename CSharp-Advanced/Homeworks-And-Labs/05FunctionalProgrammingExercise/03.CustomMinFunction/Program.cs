using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int> printSmallestNumber = x => x.Min();

            Console.WriteLine(printSmallestNumber(input));
        }
    }
}
