using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p03RageQuit
{
    class p03RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            string pattern = @"([^\d]+)(\d+)";

            var matches = Regex.Matches(input, pattern);
            
            StringBuilder result = new StringBuilder();
            var uniqueSymbols = new List<char>();
            
            foreach (Match match in matches)
            {
                var text = match.Groups[1].Value;
                int count = Int32.Parse(match.Groups[2].Value);
                
                for (int i = 0; i < count; i++)
                {
                result.Append(text);
                }
                if (count == 0)
                {
                    continue;
                }
                else
                {
                uniqueSymbols.AddRange(text);               
                }
            }
            
                Console.WriteLine($"Unique symbols used: {uniqueSymbols.Distinct().Count()}");
                Console.WriteLine(string.Join("", result));
        }
    }
}
