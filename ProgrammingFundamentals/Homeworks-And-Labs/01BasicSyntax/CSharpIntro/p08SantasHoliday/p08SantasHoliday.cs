using System;

namespace p08SantasHoliday
{
    class p08SantasHoliday
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine().ToLower();
            string rate = Console.ReadLine().ToLower();
            double price = 0;
            if (room == "room for one person")
            {
                price = 18.00 * (days - 1);
            }
            else if (room == "apartment")
            {
                if (days < 10)
                {
                    price = (25.00 * (days - 1)) * 0.7;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = (25 * (days - 1)) * 0.65;
                }
                else if (days > 15)
                {
                    price = (25 * (days - 1)) * 0.5;
                }
            }
            else if (room == "president apartment")
            {
                if (days < 10)
                {
                    price = (35.00 * (days - 1)) * 0.9;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = (35.00 * (days - 1)) * 0.85;
                }
                else if (days > 15)
                {
                    price = (35.00 * (days - 1)) * 0.80;
                }
            }
            if (rate == "positive")
            {
                price *= 1.25;
            }
            else if (rate == "negative")
            {
                price *= 0.9;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
