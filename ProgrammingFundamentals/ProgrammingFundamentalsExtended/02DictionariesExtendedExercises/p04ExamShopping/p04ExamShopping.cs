using System;
using System.Collections.Generic;

namespace p04ExamShopping
{
    class p04ExamShopping
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ');
            var products = new Dictionary<string, int>();

            int currentQuantity = int.Parse(command[2]);

            while (command[0] != "shopping" && command[1] != "time")
            {
                string name = command[1];
                currentQuantity = int.Parse(command[2]);
                if (!products.ContainsKey(name))
                {
                    products.Add(name, currentQuantity);
                }
                else
                {
                    products[name] += currentQuantity;
                }
                command = Console.ReadLine().Split(' ');
            }
            command = Console.ReadLine().Split(' ');
            while (command[0] != "exam" && command[1] != "time")
            {
                string name = command[1];
                int quantity = int.Parse(command[2]);
                
                if (!products.ContainsKey(name))
                {
                    Console.WriteLine($"{name} doesn't exist");
                }
                else if (products[name] <= 0)
                {
                    Console.WriteLine($"{name} out of stock");
                }
                else if (quantity >= products[name])
                {
                    products[name] = 0;
                }
                else
                {
                    products[name] -= quantity;
                }
                command = Console.ReadLine().Split(' ');
            }
            
            foreach (var item in products)
            {
                if (item.Value <= 0)
                {

                }
                else
                {
                Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}
