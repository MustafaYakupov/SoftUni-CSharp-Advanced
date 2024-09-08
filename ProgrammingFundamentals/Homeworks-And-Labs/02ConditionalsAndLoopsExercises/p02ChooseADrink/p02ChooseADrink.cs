using System;

namespace p02ChooseADrink
{
    class p02ChooseADrink
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            switch (profession)
            {
                case "Athlete":;
                    price = 0.70 * quantity;
                    Console.WriteLine($"The Athlete has to pay {price:f2}.");
                    break;
                case "Businessman":
               
                    price = 1.00 * quantity;
                    Console.WriteLine($"The Businessman has to pay {price:f2}.");
                    break;
                case "Businesswoman":
                    price = 1.00 * quantity;
                    Console.WriteLine($"The Businesswoman has to pay {price:f2}.");
                    break;
                case "SoftUni Student":
                    price = 1.70 * quantity;
                    Console.WriteLine($"The SoftUni Student has to pay {price:f2}.");
                    break;
                default:
                    price = 1.20 * quantity;
                    Console.WriteLine($"The {profession} has to pay {price:f2}.");
                    break;


            }
            
        }
    }
}
