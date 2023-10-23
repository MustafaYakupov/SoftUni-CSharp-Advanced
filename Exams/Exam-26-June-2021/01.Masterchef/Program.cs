using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] freshnessInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queueIngredients = new Queue<int>(ingredientsInput);
            Stack<int> stackFreshness = new Stack<int>(freshnessInput);
            Dictionary<string, int> cookedDishesDict = new Dictionary<string, int>();

            while (queueIngredients.Any() && stackFreshness.Any())
            {
                int ingredient = queueIngredients.Dequeue();

                if (ingredient == 0)
                {
                    continue;
                }

                int freshness = stackFreshness.Pop();
                int totalFreshnessLevel = ingredient * freshness;

                if (totalFreshnessLevel == 150)
                {
                    if (!cookedDishesDict.ContainsKey("Dipping sauce"))
                    {
                        cookedDishesDict.Add("Dipping sauce", 0);
                    }

                    cookedDishesDict["Dipping sauce"]++;
                }
                else if (totalFreshnessLevel == 250)
                {
                    if (!cookedDishesDict.ContainsKey("Green salad"))
                    {
                        cookedDishesDict.Add("Green salad", 0);
                    }

                    cookedDishesDict["Green salad"]++;
                }
                else if (totalFreshnessLevel == 300)
                {
                    if (!cookedDishesDict.ContainsKey("Chocolate cake"))
                    {
                        cookedDishesDict.Add("Chocolate cake", 0);
                    }

                    cookedDishesDict["Chocolate cake"]++;
                }
                else if (totalFreshnessLevel == 400)
                {
                    if (!cookedDishesDict.ContainsKey("Lobster"))
                    {
                        cookedDishesDict.Add("Lobster", 0);
                    }

                    cookedDishesDict["Lobster"]++;
                }
                else
                {
                    ingredient += 5;
                    queueIngredients.Enqueue(ingredient);
                }
            }

            if (cookedDishesDict.Values.Sum() >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (queueIngredients.Any())
            {
                Console.WriteLine($"Ingredients left: {queueIngredients.Sum()}");
            }

            foreach (var dish in cookedDishesDict.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
