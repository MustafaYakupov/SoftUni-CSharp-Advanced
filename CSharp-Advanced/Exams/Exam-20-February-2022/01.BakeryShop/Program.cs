using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] water = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double[] flour = Console.ReadLine()
               .Split(' ')
               .Select(double.Parse)
               .ToArray();

            Queue<double> queueWater = new Queue<double>(water);
            Stack<double> stackFlour = new Stack<double>(flour);
            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();

            while (queueWater.Any() && stackFlour.Any())
            {
                double currentWater = queueWater.Dequeue();
                double currentFlour = stackFlour.Pop();
                double sum = currentFlour + currentWater;
                double waterPercentage = (currentWater * 100) / sum;

                if (waterPercentage == 50)
                {
                    if (!bakedProducts.ContainsKey("Croissant"))
                    {
                        bakedProducts.Add("Croissant", 0);
                    }

                    bakedProducts["Croissant"]++;
                }
                else if (waterPercentage == 40)
                {
                    if (!bakedProducts.ContainsKey("Muffin"))
                    {
                        bakedProducts.Add("Muffin", 0);
                    }

                    bakedProducts["Muffin"]++;
                }
                else if (waterPercentage == 30)
                {
                    if (!bakedProducts.ContainsKey("Baguette"))
                    {
                        bakedProducts.Add("Baguette", 0);
                    }

                    bakedProducts["Baguette"]++;
                }
                else if (waterPercentage == 20)
                {
                    if (!bakedProducts.ContainsKey("Bagel"))
                    {
                        bakedProducts.Add("Bagel", 0);
                    }

                    bakedProducts["Bagel"]++;
                }
                else
                {
                    currentFlour -= currentWater;
                    stackFlour.Push(currentFlour);

                    if (!bakedProducts.ContainsKey("Croissant"))
                    {
                        bakedProducts.Add("Croissant", 0);
                    }

                    bakedProducts["Croissant"]++;
                }
            }

            foreach (var product in bakedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (!queueWater.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {String.Join(", ", queueWater)}");
            }

            if (!stackFlour.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", stackFlour)}");
            }
        }
    }
}
