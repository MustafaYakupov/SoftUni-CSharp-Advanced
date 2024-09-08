using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p03MatchHexademicalNumbers
{
    class p03MatchHexademicalNumbers
    {
        static void Main(string[] args)
        {
            var regex = @"\b((?:0x)?[0-9A-F]+)\b";
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, regex);

            var result = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
