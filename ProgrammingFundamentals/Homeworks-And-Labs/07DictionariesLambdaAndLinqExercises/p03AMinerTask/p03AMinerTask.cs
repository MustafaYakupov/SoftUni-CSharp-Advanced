using System;
using System.Collections.Generic;
using System.Linq;

namespace p03AMinerTask
{
    class p03AMinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mine = new Dictionary<string, int>();
            string quantityAndResources = Console.ReadLine();
            string metal = "";
            int quantity = 0;
            while (quantityAndResources != "stop")
            {
                metal = quantityAndResources;
                quantity = int.Parse(Console.ReadLine());
                if (!mine.ContainsKey(metal))
                {
                    mine.Add(metal, quantity);
                }
                else
                {
                    mine[metal] += quantity;
                }
                quantityAndResources = Console.ReadLine();
            }
            foreach (var pair in mine)
            {

            Console.WriteLine(string.Join(" -> ", pair.Key, pair.Value));
            }
        }
    }
}
