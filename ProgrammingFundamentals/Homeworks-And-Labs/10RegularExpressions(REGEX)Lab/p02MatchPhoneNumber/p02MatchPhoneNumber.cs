using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p02MatchPhoneNumber
{
    class p02MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            var regex = @"( ?\+359(\s|-)2\2\d{3}\2\d{4})\b";
            string phones = Console.ReadLine();

            var matches = Regex.Matches(phones, regex);
            

            //bool hasRegexPattern = regex.IsMatch(input);

            var matchedPhones = matches
                 .Cast<Match>()
                 .Select(x => x.Value.Trim())
                 .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
