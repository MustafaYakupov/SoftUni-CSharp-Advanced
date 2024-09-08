using System;

namespace p08CaloriesCounter
{
    class p08CaloriesCounter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double cheese = 0;
            double tomatoSauce = 0;
            double salami = 0;
            double pepper = 0;

            for (int i = 0; i < n; i++)
            {
                string ingredient = Console.ReadLine().ToLower();
                if (ingredient == "cheese")
                {
                    cheese += 500;
                }
                else if (ingredient == "tomato sauce")
                {
                    tomatoSauce += 150;
                }
                else if (ingredient == "salami")
                {
                    salami += 600;
                }
                else if (ingredient == "pepper")
                {
                    pepper += 50;
                }
            }
            double totalCalories = cheese + tomatoSauce + salami + pepper;
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
