using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantityForTheDay = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            int biggestOrder = ordersQueue.Max();

            Console.WriteLine(biggestOrder);

            while (true)
            {
                if (foodQuantityForTheDay >= ordersQueue.Peek())
                {
                    foodQuantityForTheDay -= ordersQueue.Dequeue();

                    if (!ordersQueue.Any())
                    {
                        Console.WriteLine("Orders complete");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    break;
                }
            }
        }
    }
}
