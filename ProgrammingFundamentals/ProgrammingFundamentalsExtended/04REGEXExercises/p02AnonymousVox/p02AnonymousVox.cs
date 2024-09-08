using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p02AnonymousVox
{
    class p02AnonymousVox
    {
        static void Main(string[] args)
        {
            string placeholderPattern = @"([A-Za-z]+)(.+)(\1)";

            string text = Console.ReadLine();
            string[] values = Console.ReadLine().Split(new[] {  '{', '}' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            var textMatches = Regex.Matches(text, placeholderPattern);
            
            int index = 0;
            foreach (Match m in textMatches)
            {
                text = text.Replace(m.Groups[2].Value, values[index].ToString());
                index++;
            }

            Console.WriteLine(text);
        }
    }
}
