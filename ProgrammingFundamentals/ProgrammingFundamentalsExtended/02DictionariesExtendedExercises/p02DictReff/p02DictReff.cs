using System;
using System.Collections.Generic;

namespace p02DictReff
{
    class p02DictReff
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var resultDict = new Dictionary<string, int>();

            while (input[0] != "end")
            {
                
                bool isNumber = int.TryParse(input[2], out int num);

                if (isNumber)
                {
                    resultDict[input[0]] = num;
                }
                else
                {
                    if (resultDict.ContainsKey(input[2]))
                    {
                        resultDict[input[0]] = resultDict[input[2]];
                    }
                }
                input = Console.ReadLine().Split();
            }
            foreach (var item in resultDict)
            {
                Console.WriteLine($"{item.Key} === {item.Value}");
            }
        }
    }
}
