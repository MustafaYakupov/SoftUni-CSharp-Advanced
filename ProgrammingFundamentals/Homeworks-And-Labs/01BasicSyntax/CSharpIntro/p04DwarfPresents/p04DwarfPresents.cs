using System;

namespace p04DwarfPresents
{
    class p04DwarfPresents
    {
        static void Main(string[] args)
        {
            int dwarves = int.Parse(Console.ReadLine());
            int money = int.Parse(Console.ReadLine());
            double price = 0;

            for (int i = 1; i <= dwarves; i++)
            {
                string present = Console.ReadLine().ToLower();
                if (present == "sand clock")
                {
                    price += 2.20;
                }
                else if (present == "magnet")
                {
                    price += 1.50;
                }
                else if (present == "cup")
                {
                    price += 5.00;
                }
                else if (present == "t-shirt")
                {
                    price += 10.00;
                }
            }
            if (money >= price)
            {
                Console.WriteLine($"Santa Claus has {money - price:f2} more leva left!");
            }
            else
            {
                Console.WriteLine($"Santa Claus will need {price - money:f2} more leva.");
            }
        }
    }
}
