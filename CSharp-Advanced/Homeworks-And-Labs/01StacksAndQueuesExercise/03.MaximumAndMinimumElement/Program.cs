using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());

            var stackOfNumbers = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] commandInfo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

                int actionToPerform = commandInfo[0];

                if (actionToPerform == 1)
                {
                    stackOfNumbers.Push(commandInfo[1]);
                }
                else if (actionToPerform == 2)
                {
                    if (stackOfNumbers.Any())
                    {
                        stackOfNumbers.Pop();
                    }
                }
                else if (actionToPerform == 3 && stackOfNumbers.Any())
                {
                    Console.WriteLine(stackOfNumbers.Max());
                }
                else if (actionToPerform == 4 && stackOfNumbers.Any())
                {
                    Console.WriteLine(stackOfNumbers.Min());
                }
            }

            Console.WriteLine(String.Join(", ", stackOfNumbers));
            
        }
    }
}
