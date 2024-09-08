using System;
using System.Collections.Generic;
using System.Linq;

namespace p02OddOccurences
{
    class p02OddOccurences
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split(' ').ToArray();
            var count = new Dictionary<string, int>();
            
            foreach (var word in words)
            {
                if (!count.ContainsKey(word))
                {
                    count[word] = 1;
                }
                else
                {
                    count[word]++;
                }
            }

            List<string> result = new List<string>();
            foreach (var item in count)
            {
                if (item.Value % 2 != 0)
                {
                    result.Add(item.Key);
                }
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
