using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] roses = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfLilies = new Stack<int>(lilies);
            Queue<int> queueOfRoses = new Queue<int>(roses);

            int wreathsCreated = 0;
            int storedFlowers = 0;

            while (stackOfLilies.Any() && queueOfRoses.Any())
            {
                int currentLili = stackOfLilies.Pop();
                int currentRose = queueOfRoses.Peek();
                int sum = currentLili + currentRose;

                if (sum == 15)
                {
                    queueOfRoses.Dequeue();
                    wreathsCreated++;
                }
                else if (sum > 15)
                {
                    stackOfLilies.Push(currentLili - 2);
                }
                else if (sum < 15)
                {
                    queueOfRoses.Dequeue();
                    storedFlowers += sum;
                }
            }

            while (storedFlowers >= 15)
            {
                wreathsCreated++;
                storedFlowers -= 15;
            }

            if (wreathsCreated >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCreated} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCreated} wreaths more!");
            }
        }
    }
}