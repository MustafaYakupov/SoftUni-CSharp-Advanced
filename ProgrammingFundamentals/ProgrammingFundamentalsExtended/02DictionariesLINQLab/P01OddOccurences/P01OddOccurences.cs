using System;
using System.Collections.Generic;
using System.Linq;

namespace P01OddOccurences
{
    class P01OddOccurences
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().ToLower().Split(' ').ToArray();

            var result = new List<string>();
            var dict = new Dictionary<string, int>();

            foreach (var word in arr)
            {
                if (dict.ContainsKey(word) == false)
                {
                    dict.Add(word, 1);
                }
                else
                {
                    dict[word]++;
                }
            }

            foreach (var kvp in dict.Distinct())
            {
                if (kvp.Value % 2 != 0)
                {
                    result.Add(kvp.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
