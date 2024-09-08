using System;
using System.Text.RegularExpressions;

namespace p03Snowflake
{
    class p03Snowflake
    {
        static void Main(string[] args)
        {
            string surfaceTop = Console.ReadLine();
            string mantleTop = Console.ReadLine();
            string middle = Console.ReadLine();
            string mantleBottom = Console.ReadLine();
            string surfaceBottom = Console.ReadLine();

            string surfacePattern = @"^[^A-Za-z0-9]+$";
            string mantlePattern = @"^[0-9_]+$";
            string middlePattern = @"^([^A-Za-z0-9]+)([0-9_]+)([A-Za-z]+)([0-9_]+)([^A-Za-z0-9]+)$";

            var surfaceTopMatch = Regex.Match(surfaceTop, surfacePattern);
            var mantleTopMatch = Regex.Match(mantleTop, mantlePattern);
            var middleMatch = Regex.Match(middle, middlePattern);
            var mantleBottomMatch = Regex.Match(mantleBottom, mantlePattern);
            var surfaceBottomMatch = Regex.Match(surfaceBottom, surfacePattern);

            if (surfaceTopMatch.Success != true || mantleTopMatch.Success != true || middleMatch.Success != true
                || surfaceBottomMatch.Success != true || mantleBottomMatch.Success != true)
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                Console.WriteLine("Valid");
                Console.WriteLine(middleMatch.Groups[3].Length);
            }
        }
    }
}
