using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p06MatchPhoneNumber
{
    class p06MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string pattern = @"( ?\+359(\s|-)2\2\d{3}\2\d{4})\b";

            string numbers = Console.ReadLine();

            var matches = Regex.Matches(numbers, pattern);

            var result = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
