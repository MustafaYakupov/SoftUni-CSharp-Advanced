using System;

namespace p02ChristmasPreparation
{
    class p02ChristmasPreparation
    {
        static void Main(string[] args)
        {
            int pepperCount = int.Parse(Console.ReadLine());
            int textileCount     = int.Parse(Console.ReadLine());
            double glueQuantity = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pepperPrice = pepperCount * 5.80;
            double textilePrice = textileCount * 7.20;
            double gluePrice = glueQuantity * 1.20;
            double price = pepperPrice + textilePrice + gluePrice;
            double totalPrice = price - ((price * discount) / 100);
            Console.WriteLine($"{totalPrice:f3}");

        }


            
    }
}
