using System;

namespace p03RestaurantDiscount
{
    class p03RestaurantDiscount
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine().ToLower();
            string hallName="";
            double hallPrice;
            double price=0;

            if (groupSize <= 50)
            {
                hallName = "Small Hall";
                hallPrice = 2500;
                if (package == "normal")
                {
                    price = (hallPrice + 500) * 0.95;
                }
                else if (package == "gold")
                {
                    price = (hallPrice + 750) * 0.90;
                }
                else if (package == "platinum")
                {
                    price = (hallPrice + 1000) * 0.85;
                }
            }
            else if (groupSize <= 100)
            {
                hallName = "Terrace";
                hallPrice = 5000;
                if (package == "normal")
                {
                    price = (hallPrice + 500) * 0.95;
                }
                else if (package == "gold")
                {
                    price = (hallPrice + 750) * 0.90;
                }
                else if (package == "platinum")
                {
                    price = (hallPrice + 1000) * 0.85;
                }
            }
            else if (groupSize <= 120)
            {
                hallName = "Great Hall";
                hallPrice = 7500;
                if (package == "normal")
                {
                    price = (hallPrice + 500) * 0.95;
                }
                else if (package == "gold")
                {
                    price = (hallPrice + 750) * 0.90;
                }
                else if (package == "platinum")
                {
                    price = (hallPrice + 1000) * 0.85;
                }
            }
            if (groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }
            double pricePerPerson = price / groupSize;
            Console.WriteLine($"We can offer you the {hallName}");
            Console.WriteLine($"The price per person is {pricePerPerson:f2}$");
            
        }
    }
}
