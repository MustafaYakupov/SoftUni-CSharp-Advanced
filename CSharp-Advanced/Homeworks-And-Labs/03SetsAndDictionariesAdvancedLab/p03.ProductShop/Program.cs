using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, Dictionary<string, double>> productDict = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "Revision")
                {
                    break;
                }

                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!productDict.ContainsKey(shop))
                {
                    productDict[shop] = new Dictionary<string, double>();
                }

                //productDict[shop].Add(product, price); 
                productDict[shop][product] = price;
            }

            var orderedDict = productDict.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedDict)
            {
                string shop = kvp.Key;
                var products = kvp.Value;

                Console.WriteLine($"{shop}->");

                foreach (var item in products)
                {
                    var productName = item.Key;
                    double price = item.Value;

                    Console.WriteLine($"Product:{productName}, Price: {price}");
                }
            }
        }
    }
}
