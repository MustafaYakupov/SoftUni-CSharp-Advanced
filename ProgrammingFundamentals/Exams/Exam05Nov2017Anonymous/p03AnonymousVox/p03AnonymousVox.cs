using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p03AnonymousVox
{
    class p03AnonymousVox
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] placeholders = Console.ReadLine().Split("{}".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"([A-Za-z]+)(.+)(\1)";
            var matches = Regex.Matches(text, pattern);

            int count = 0;

            foreach (Match match in matches)
            {
                string decodedMessage = match.Groups[1] + placeholders[count++] + match.Groups[3];
                text = text.Replace(match.Value, decodedMessage);
            }
            Console.WriteLine(text);
        }
    }
}
