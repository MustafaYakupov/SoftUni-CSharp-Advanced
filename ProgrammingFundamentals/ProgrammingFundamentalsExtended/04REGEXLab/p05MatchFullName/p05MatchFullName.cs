using System;
using System.Text.RegularExpressions;

namespace p05MatchFullName
{
    class p05MatchFullName
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            var matches = Regex.Matches(text, pattern);

            foreach (Match name in matches)
            {
                Console.Write(name.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
