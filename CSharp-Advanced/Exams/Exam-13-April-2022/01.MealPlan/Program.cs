namespace _01.MealPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mealNames = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int[] dailyCalories = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfMeals = new Queue<int>();
            Stack<int> stackOfCalories = new Stack<int>(dailyCalories);
            int mealsCount = 0;

            foreach (var meal in mealNames)
            {
                if (meal == "salad")
                {
                    queueOfMeals.Enqueue(350);
                }
                else if (meal == "soup")
                {
                    queueOfMeals.Enqueue(490);
                }
                else if (meal == "pasta")
                {
                    queueOfMeals.Enqueue(680);
                }
                else if (meal == "steak")
                {
                    queueOfMeals.Enqueue(790);
                }
            }

            while (queueOfMeals.Any() && stackOfCalories.Any())
            {
                int meal = queueOfMeals.Dequeue();
                int calories = stackOfCalories.Pop();

                
                 if (calories - meal >= 0)
                 {
                    mealsCount++;
                     calories -= meal;
                     stackOfCalories.Push(calories);
                 }
                else if (calories - meal < 0)
                {
                    meal -= calories;
                    mealsCount++;

                    if (stackOfCalories.Any())
                    {
                        int nextDayCallories = stackOfCalories.Pop();
                        nextDayCallories -= meal;
                        stackOfCalories.Push(nextDayCallories);
                    }
                }
            }

            if (!queueOfMeals.Any() && stackOfCalories.Any())
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", stackOfCalories)} calories.");
            }

            if (queueOfMeals.Any())
            {
                Queue<string> mealsLeft = new Queue<string>();

                foreach (var meal in queueOfMeals)
                {
                    if (meal == 350)
                    {
                        mealsLeft.Enqueue("salad");
                    }
                    else if (meal == 490)
                    {
                        mealsLeft.Enqueue("soup");
                    }
                    else if (meal == 680)
                    {
                        mealsLeft.Enqueue("pasta");
                    }
                    else if (meal == 790)
                    {
                        mealsLeft.Enqueue("steak");
                    }
                }

                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsLeft)}.");
            }
        }
    }
}