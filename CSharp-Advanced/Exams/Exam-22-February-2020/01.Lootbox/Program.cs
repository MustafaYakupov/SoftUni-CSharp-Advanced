using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondBoxInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queueFirst = new Queue<int>(firstBoxInput);
            Stack<int> stackSecond = new Stack<int>(secondBoxInput);
            int claimedItems = 0;

            while (queueFirst.Any() && stackSecond.Any())
            {
                int first = queueFirst.Peek();
                int second = stackSecond.Pop();
                int sum = first + second;

                if (sum % 2 == 0) // Is even number
                {
                    claimedItems += sum;
                    queueFirst.Dequeue();
                }
                else
                {
                    queueFirst.Enqueue(second);
                }
            }

            if (!queueFirst.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!stackSecond.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
