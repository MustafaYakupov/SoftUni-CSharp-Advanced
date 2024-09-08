using System;
using System.Collections.Generic;
using System.Linq;

namespace p04AnonymousCache
{
    class p04AnonymousCache
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var data = new Dictionary<string, Dictionary<string, long>>();

            while (input != "thetinggoesskrra")
            {
                string[] inputSplit = input.Split(" ->|".ToCharArray(), 
                    StringSplitOptions.RemoveEmptyEntries);

                if (inputSplit.Length > 1)
                {
                    string dataKey = inputSplit[0];
                    long dataSize = long.Parse(inputSplit[1]);
                    string dataSet = inputSplit[2];

                    if (data.ContainsKey(dataSet) == false)
                    {
                        data.Add(dataSet, new Dictionary<string, long>());
                    }
                    data[dataSet][dataKey] = dataSize;
                }
                
                input = Console.ReadLine();
            }

            if (data.Count > 1)
            {
                var dataSetWithMaxSize = data.OrderByDescending(x => x.Value.Sum(d => d.Value)).First();

                Console.WriteLine($"Data Set: {dataSetWithMaxSize.Key}, Total Size: {dataSetWithMaxSize.Value.Sum(d => d.Value)}");

                foreach (var inner in dataSetWithMaxSize.Value)
                {
                    Console.WriteLine($"$.{inner.Key}");
                }
            }
        }
    }
}
