using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffee = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] milk = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queueOfCoffee = new Queue<int>(coffee);
            Stack<int> stackOfMilk = new Stack<int>(milk);
            Dictionary<string, int> drinksMade = new Dictionary<string, int>();

            while (queueOfCoffee.Any() && stackOfMilk.Any())
            {
                int coffeAmount = queueOfCoffee.Dequeue();
                int milkAmount = stackOfMilk.Pop();
                int sum = coffeAmount + milkAmount;

                if (sum == 50)
                {
                    MakeADrink(drinksMade, "Cortado");
                }
                else if (sum == 75)
                {
                    MakeADrink(drinksMade, "Espresso");
                }
                else if (sum == 100)
                {
                    MakeADrink(drinksMade, "Capuccino");
                }
                else if (sum == 150)
                {
                    MakeADrink(drinksMade, "Americano");
                }
                else if (sum == 200)
                {
                    MakeADrink(drinksMade, "Latte");
                }
                else
                {
                    milkAmount -= 5;
                    stackOfMilk.Push(milkAmount);
                }
            }

            if (!queueOfCoffee.Any() && !stackOfMilk.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (!queueOfCoffee.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.Write($"Coffee left: ");
                Console.WriteLine(String.Join(", ", queueOfCoffee));
            }
            if (!stackOfMilk.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.Write("Milk left: ");
                Console.WriteLine(String.Join(", ", stackOfMilk));
            }

            foreach (var kvp in drinksMade.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static void MakeADrink(Dictionary<string, int> drinksMade, string drink)
        {
            if (!drinksMade.ContainsKey(drink))
            {
                drinksMade.Add(drink, 0);
            }

            drinksMade[drink]++;
        }
    }
}