using System;

namespace p02DeerOfSanta
{
    class p02DeerOfSanta
    {
        static void Main(string[] args)
        {
            int daysMissing = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double food1 = double.Parse(Console.ReadLine());
            double food2 = double.Parse(Console.ReadLine());
            double food3 = double.Parse(Console.ReadLine());

            double deer1 = daysMissing * food1;
            double deer2 = daysMissing * food2;
            double deer3 = daysMissing * food3;
            double totalFood = deer1 + deer2 + deer3;
            if (foodLeft > totalFood)
            {
                Console.WriteLine($"{Math.Floor(foodLeft - totalFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFood - foodLeft)} more kilos of food are needed.");  
            }
        }
    }
}
