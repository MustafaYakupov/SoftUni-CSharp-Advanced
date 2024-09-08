using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace p05KeyReplcer
{
    class p05KeyReplcer
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();
            string keyPattern = @"((^|(?<=\s))(.+?)([\|<\\])).+?([\|<\\])(.+)";
            var keyMatches = Regex.Match(key, keyPattern);
            var startKey = keyMatches.Groups[3].Value;
            var endKey = keyMatches.Groups[6].Value;

            //var keyMatches = Regex.Matches(key, keyPattern);
            // foreach (Match match in keyMatches)
            // {
            //     startKey = match.Groups[3].Value;
            //     endKey = match.Groups[6].Value;
            // }

            var textPattern = $@"(({startKey})(.*?)({endKey}))";
            var textMatches = Regex.Matches(text, textPattern);
            
            List <string> result = new List<string>();
            
            foreach (Match match in textMatches)
            {
                if (match.Groups[3].ToString() != "")
                {
                result.Add(match.Groups[3].Value);
                }
            }
            if (result.Count == 0)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
            Console.WriteLine(string.Join("", result));
            }
        }
    }
}
