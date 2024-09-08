using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p05MatchNumbers
{
    class p05MatchNumbers
    {
        static void Main(string[] args)
        {
            var regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            
            string input = Console.ReadLine();

            var matches = Regex.Matches(input, regex);

            var result = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
