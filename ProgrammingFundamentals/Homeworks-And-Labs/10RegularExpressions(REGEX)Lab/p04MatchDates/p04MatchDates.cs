using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p04MatchDates
{
    class p04MatchDates
    {
        static void Main(string[] args)
        {
            var regex = @"((?<date>\d{2})(?<separator>\/|\.|-)(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4}))";

            var input = Console.ReadLine();
            var matches = Regex.Matches(input, regex);

            var result = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            foreach (Match match in matches)
            {
                var day = match.Groups["date"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
