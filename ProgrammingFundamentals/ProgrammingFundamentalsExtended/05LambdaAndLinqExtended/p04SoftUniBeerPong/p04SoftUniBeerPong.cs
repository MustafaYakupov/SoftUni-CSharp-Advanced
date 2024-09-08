using System;
using System.Collections.Generic;
using System.Linq;

namespace p04SoftUniBeerPong
{
    class p04SoftUniBeerPong
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var results = new Dictionary<string, Dictionary<string, int>>();

            while (text != "stop the game")
            {
                string[] input = text.Split('|').ToArray();
                string player = input[0];
                string team = input[1];
                int points = int.Parse(input[2]);

                if (results.ContainsKey(team) == false)
                {
                    results[team] = new Dictionary<string, int>();
                }
                if (results[team].Values.Count == 3)
                {
                    text = Console.ReadLine();
                    continue;
                }
                results[team][player] = points;
                text = Console.ReadLine();
            }

            int count = 0;

            foreach (var keyValuePair in results.Where(x => x.Value.Count == 3).OrderByDescending(x => x.Value.Values.Sum()))
            {
                count++;
                Console.WriteLine($"{count}. {keyValuePair.Key}; Players:");

                foreach (var pair in keyValuePair.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
