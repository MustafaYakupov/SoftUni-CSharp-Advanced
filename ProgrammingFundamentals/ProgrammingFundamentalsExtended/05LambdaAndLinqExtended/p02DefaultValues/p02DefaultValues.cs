using System;
using System.Collections.Generic;
using System.Linq;

namespace p02DefaultValues
{
    class p02DefaultValues
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            var originalDict = new Dictionary<string, string>();
            var  defaultDict = new Dictionary<string, string>();

            string name = "";

            while (input[0] != "end")
            {
                if (input[2] == "null")
                {
                    name = input[0];
                    if (defaultDict.ContainsKey(input[0]) == false)
                    {
                        defaultDict.Add(input[0], input[2]);
                    }
                    else
                    {
                        defaultDict[name] = input[2];
                    }
                }
                else
                {
                    if (originalDict.ContainsKey(input[0]) == false)
                    {
                        originalDict.Add(input[0], input[2]);
                    }
                    else
                    {
                        originalDict[input[0]] = input[2];
                    }
                }
                input = Console.ReadLine().Split(' ');
            }
            input = Console.ReadLine().Split(' ');

            originalDict = originalDict.OrderByDescending(x => x.Value.Length).ToDictionary(x => x.Key, x => x.Value);

            var modifiedDictionary = new Dictionary<string, string>();

            foreach (var pair in defaultDict)
            {
                modifiedDictionary.Add(pair.Key, input[0]); 
            }

            foreach (var pair in originalDict)
            {
                Console.WriteLine($"{pair.Key} <-> {pair.Value}");
            }

            foreach (var pair in modifiedDictionary)
            {
                Console.WriteLine($"{pair.Key} <-> {pair.Value}");
            }
        }
    }
}
