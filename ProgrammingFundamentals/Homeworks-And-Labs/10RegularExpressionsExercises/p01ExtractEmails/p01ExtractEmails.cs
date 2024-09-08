using System;
using System.Text.RegularExpressions;

namespace p01ExtractEmails
{
    class p01ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var pattern = @"(^|(?<=\s))([A-Za-z0-9]+)([-\._]?[a-z0-9])*@([A-Za-z0-9])+([-.]?[a-z0-9])*\.([a-z0-9]+)([\.][a-z0-9]+)*";
            var matches = Regex.Matches(input, pattern);

            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }
        }
    }
}
