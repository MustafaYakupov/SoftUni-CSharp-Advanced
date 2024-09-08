using System;
using System.Linq;

namespace p01ArraysStatistics
{
    class p01ArraysStatistics
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var min = arr.Min();
            var max = arr.Max();
            var sum = arr.Sum();
            var average = arr.Average();

            Console.WriteLine($"Min = {min}\nMax = {max}\nSum = {sum}\nAverage = {average}");
        }
    }
}
