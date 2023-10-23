using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] caffeineMiligrams = Console.ReadLine()        //Stack
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] energyDrinks = Console.ReadLine()              //Queue
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalCaffein = 0;
            Stack<int> caffeineStack = new Stack<int>(caffeineMiligrams);
            Queue<int> drinksQueue = new Queue<int>(energyDrinks);

            while (caffeineStack.Any() && drinksQueue.Any())
            {
                int currentCaffeineInDrink = caffeineStack.Pop();
                int currentDrink = drinksQueue.Dequeue();
                int caffeine = currentCaffeineInDrink * currentDrink;

                if (caffeine + totalCaffein <= 300)
                {
                    totalCaffein += caffeine;
                }
                else
                {
                    drinksQueue.Enqueue(currentDrink);
                    if (totalCaffein >= 30)
                    {
                        totalCaffein -= 30;
                    }
                }
            }

            if (drinksQueue.Any())
            {
                Console.WriteLine($"Drinks left: { string.Join(", ", drinksQueue)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {totalCaffein} mg caffeine.");
        }
    }
}
