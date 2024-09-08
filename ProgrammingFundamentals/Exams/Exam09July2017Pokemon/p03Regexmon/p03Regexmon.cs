using System;
using System.Text.RegularExpressions;

namespace p03Regexmon
{
    class p03Regexmon
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var didimonPattern = @"([^A-Za-z-]+)";
            var bojomonPattern = @"([A-Za-z]+-[A-Za-z]+)";
            
            int round = 1;

            while (true)
            {
                if (round % 2 == 1)
                {
                    if (Regex.IsMatch(input, didimonPattern) == false)
                    {
                        return;
                    }
                    else
                    {
                        Match currentMatch = Regex.Match(input, didimonPattern);
                        input = input.Substring(currentMatch.Index + currentMatch.Length);
                        Console.WriteLine(currentMatch.ToString());
                    }
                }
                else
                {
                    if (Regex.IsMatch(input, bojomonPattern) == false)
                    {
                        return;
                    }
                    else
                    {
                        Match currentMatch = Regex.Match(input, bojomonPattern);
                        input = input.Substring(currentMatch.Index + currentMatch.Length);
                        Console.WriteLine(currentMatch.ToString());
                    }
                }
                round++;
            }
        }
    }
}
