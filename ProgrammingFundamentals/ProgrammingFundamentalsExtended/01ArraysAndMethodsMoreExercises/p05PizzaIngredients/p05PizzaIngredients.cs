using System;
using System.Collections.Generic;
using System.Linq;

namespace p05PizzaIngredients
{
    class p05PizzaIngredients
    {
        static void Main(string[] args)
        {
            string[] possibleIngredients = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int length = int.Parse(Console.ReadLine());

            var usedIngredients = new List<string>();

            foreach (var ingredient in possibleIngredients)
            {
                if (ingredient.Length == length)
                {
                    if (usedIngredients.Count >= 10)
                    {
                        break;
                    }
                    usedIngredients.Add(ingredient);
                }
            }

            foreach (var ingredient in usedIngredients)
            {
                Console.WriteLine($"Adding {ingredient}.");
            }

            Console.WriteLine($"Made pizza with total of {usedIngredients.Count} ingredients.");
            Console.Write("The ingredients are: ");
            Console.WriteLine($"{string.Join(", ", usedIngredients)}.");
        }
    }
}
