using System;

namespace p07CakeIngredients
{
    class p07CakeIngredients
    {
        static void Main(string[] args)

        {
            string input= "";
            int count = 0;
            while (input != "Bake!" )
            {
                count++;
                input = Console.ReadLine();
                if (input != "Bake!")
                    Console.WriteLine($"Adding ingredient {input}.");
                else
                    break;
            }
            Console.WriteLine($"Preparing cake with {count -1} ingredients.");
        }
    }
}
