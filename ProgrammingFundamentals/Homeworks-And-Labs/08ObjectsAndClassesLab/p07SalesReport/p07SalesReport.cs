using System;
using System.Collections.Generic;

namespace p07SalesReport
{
    class p07SalesReport
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var sales = new SortedDictionary<string, Sale>();

            for (int i = 0; i < n; i++)
            {
                var sale = ReadSale();

                if (sales.ContainsKey(sale.Town))
                {
                    sales[sale.Town].Add(sale);
                }
                else
                {
                    sales[sale.Town] =  new List<Sale>();
                }
            }

            foreach (var salesByTown in sales)
            {
                var town = salesByTown.Key;
            }
        }

        static Sale ReadSale()
        {
            var saleParts = Console.ReadLine().Split(' ');
            return new Sale
            {
                Town = saleParts[0],
                Product = saleParts[1],
                Price = decimal.Parse(saleParts[2]),
                Quantity = double.Parse(saleParts[3])
            };
        }
    }
}
