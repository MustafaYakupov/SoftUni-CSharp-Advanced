using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int[] numbers = Enumerable.Range(1, endNumber).ToArray();

            foreach (var divider in dividers)
            {
                predicates.Add(n => n % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;
                foreach (var match in predicates)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
