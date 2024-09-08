using System;
using System.Collections.Generic;
using System.Linq;

namespace P03CitiesByContinentsAndCountries
{
    class P03CitiesByContinentsAndCountries
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            var resultDict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputs; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (resultDict.ContainsKey(continent) == false)
                {
                    List<string> cities = new List<string>();
                    cities.Add(city);
                    Dictionary<string, List<string>> current = new Dictionary<string, List<string>>();
                    current.Add(country, cities);
                    resultDict.Add(continent, current);
                }
                else
                {
                    if (resultDict[continent].ContainsKey(country) == false)
                    {
                        List<string> cities = new List<string>();
                        cities.Add(city);
                        resultDict[continent].Add(country, cities);
                    }
                    else
                    {
                        resultDict[continent][country].Add(city);
                    }
                }
            }

            foreach (var kvp in resultDict)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var innerKvp in kvp.Value)
                {
                    Console.WriteLine($"{innerKvp.Key} -> {string.Join(", ", innerKvp.Value)}");
                }
            }
        }
    }
}
