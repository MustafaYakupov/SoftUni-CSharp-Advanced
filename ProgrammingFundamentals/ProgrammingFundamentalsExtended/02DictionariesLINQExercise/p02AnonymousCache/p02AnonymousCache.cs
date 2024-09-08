using System;
using System.Collections.Generic;
using System.Linq;

namespace p02AnonymousCache
{
    class p02AnonymousCache
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dataDict = new Dictionary<string, Dictionary<string, int>>();
            var cacheDict = new Dictionary<string, Dictionary<string, int>>();

            while (input != "thetinggoesskrra")
            {
                if (input.Contains("->"))
                {
                    string[] tokens = input.Split(new[] { '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string dataSet = tokens[2].Trim();
                    string dataKey = tokens[0].Trim();
                    int dataSize = int.Parse(tokens[1].Trim());

                    if (dataDict.ContainsKey(dataSet) == false)
                    {
                        if (cacheDict.ContainsKey(dataSet) == false)
                        {
                            cacheDict.Add(dataSet, new Dictionary<string, int>());
                            cacheDict[dataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            cacheDict[dataSet].Add(dataKey, dataSize);
                        }

                    }
                    else
                    {
                        dataDict[dataSet].Add(dataKey, dataSize);
                    }
                }
                else
                {
                    string dataSet = input;

                    if (cacheDict.ContainsKey(dataSet))
                    {
                       dataDict.Add(dataSet, cacheDict[dataSet]);
                       cacheDict.Remove(dataSet);
                    }
                    else
                    {
                        dataDict.Add(dataSet, new Dictionary<string, int>());
                    }
                }

                input = Console.ReadLine();
            }


            var resultDataSet = GetMaxDataSizes(dataDict);
            var maxSum = GetSum(dataDict);

            if (dataDict.ContainsKey(resultDataSet))
            {
                Console.WriteLine($"Data Set: {resultDataSet}, Total Size: {maxSum}");

                foreach (var pair in dataDict[resultDataSet])
                {
                    Console.WriteLine($"$.{pair.Key}");
                }
            }
        }


        private static int GetSum(Dictionary<string, Dictionary<string, int>> dataDict)
        {
            var sum = 0;
            var maxSum = 0;
            string currentDataSet = string.Empty;
            string resultDataSet = string.Empty;

            foreach (var pair in dataDict)
            {
                foreach (var kvp in pair.Value)
                {
                    sum += kvp.Value;
                    currentDataSet = pair.Key;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    resultDataSet = currentDataSet;
                }
                sum = 0;
            }

            return maxSum;
        }

        private static string GetMaxDataSizes(Dictionary<string, Dictionary<string, int>> dataDict)
        {
            var sum = 0;
            var maxSum = 0;
            string currentDataSet = string.Empty;
            string resultDataSet = string.Empty;

            foreach (var pair in dataDict)
            {
                foreach (var kvp in pair.Value)
                {
                    sum += kvp.Value;
                    currentDataSet = pair.Key;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    resultDataSet = currentDataSet;
                }
                sum = 0;
            }

            return resultDataSet;
        }
    }
}
