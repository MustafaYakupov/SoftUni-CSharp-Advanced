using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> bottlesStack = new Stack<int>(bottles);
            Queue<int> cupsQueue = new Queue<int>(cups);

            var reversedCupsQueue = new Queue<int>();

            int wastedLitersOfWater = 0;

            while (true)
            {
                if (cupsQueue.Count() == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLitersOfWater}");
                    return;
                }

                if (bottlesStack.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLitersOfWater}");
                    return;
                }

                if (bottlesStack.Peek() >= cupsQueue.Peek())
                {
                    wastedLitersOfWater += bottlesStack.Peek() - cupsQueue.Peek();
                    cupsQueue.Dequeue();
                    bottlesStack.Pop();
                }
                else if (cupsQueue.Peek() > bottlesStack.Peek())
                {
                    int cupCapacityLeft = cupsQueue.Peek() - bottlesStack.Peek();

                    bottlesStack.Pop();
                    cupsQueue.Dequeue();

                    reversedCupsQueue = new Queue<int>(cupsQueue.Reverse());
                    reversedCupsQueue.Enqueue(cupCapacityLeft);
                    cupsQueue = new Queue<int>(reversedCupsQueue.Reverse());
                }
            }
        }
    }
}
