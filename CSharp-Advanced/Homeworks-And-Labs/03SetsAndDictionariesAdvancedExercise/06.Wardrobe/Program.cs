using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colorClothCount = new Dictionary<string, Dictionary<string, int>>();


            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];

                 string[] clothes = input[1].Split(',').ToArray();

                if (!colorClothCount.ContainsKey(color))
                {
                    colorClothCount[color] = new Dictionary<string, int>();
                }

                foreach (var item in clothes)
                {
                    if (!colorClothCount[color].ContainsKey(item))
                    {
                        colorClothCount[color][item] = 0;
                    }

                    colorClothCount[color][item]++;
                }
            }

            string[] itemToCheckArgs = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            string colorToCheck = itemToCheckArgs[0];
            string itemToCheck = itemToCheckArgs[1];

            foreach (var kvp in colorClothCount)
            {
                string color = kvp.Key;
                var clothCount = kvp.Value;

                Console.WriteLine($"{color} clothes:");

                foreach (var pair in clothCount)
                {
                    string cloth = pair.Key;
                    int count = pair.Value;

                    if (color == colorToCheck && cloth == itemToCheck)
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
