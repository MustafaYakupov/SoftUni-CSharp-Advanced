using System;
using System.Text.RegularExpressions;
namespace MatchFullName01
{
    class p01MatchFullName
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine(); 

            var pattern =(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }
            

          

            //var text = "Text 123 text 456";
            //var regex = new Regex(@"(\w+)\s(\d+)");
            //
            //var firstMatch = regex.Match(text);
            //
            //Console.WriteLine(firstMatch.Value);
            //
            //var result = regex.IsMatch(text);
            //
            //var matches = regex.Matches(text);
            //
            //Console.WriteLine(matches.Count);
            //
            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.Groups[2]);
            //}
        }
    }
}
