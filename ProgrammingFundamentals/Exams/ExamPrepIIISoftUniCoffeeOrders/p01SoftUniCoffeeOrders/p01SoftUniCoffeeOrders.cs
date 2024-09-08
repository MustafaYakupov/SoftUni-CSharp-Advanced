using System;
using System.Collections.Generic;
using System.Linq;

namespace p01SoftUniCoffeeOrders
{
    class p01SoftUniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());

            decimal totalPrice = 0m;
            
            var outputPrice = new List<decimal>();

            for (int i = 0; i < orders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string[] orderDate = Console.ReadLine().Split("/".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray(); 
                long capsulesCount = long.Parse(Console.ReadLine());

                int days = DateTime.DaysInMonth(int.Parse(orderDate[2]), int.Parse(orderDate[1]));
                
                decimal price = (days * capsulesCount) * pricePerCapsule;
                outputPrice.Add(price);
                totalPrice += price;
                    
            }

            foreach (var price in outputPrice)
            {
                Console.WriteLine($"The price for the coffee is: ${price:F2}");

            }
                Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
