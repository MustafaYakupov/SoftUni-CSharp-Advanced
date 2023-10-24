using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            Func<int, int, List<int>> generateRange = (start, end) =>
            {
                List<int> range = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }

                return range;
            };

            Func<string, int, bool> evenOddMatch = (condition, number) =>
            {
                if (condition == "even")
                {
                    return number % 2 == 0;
                }
                else 
                {
                    return number % 2 != 0;
                }
            };


            List<int> numbers = generateRange(input[0], input[1]);

            foreach (var number in numbers)
            {
                if (evenOddMatch(command, number))
                {
                    Console.Write($"{number} ");
                }
            }

        }
    }
}
