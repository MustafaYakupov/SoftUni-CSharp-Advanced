using System;
using System.Text.RegularExpressions;

namespace ReplaceTag06
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                var regex = new Regex(@"<a.*href=""(.*?)"">(.*?)<\/a>");
                //string pattern = @"<a.+href=""(.+?)"">""(.+?)""<\/a>";
                //string replacement = @"[URL href=\"$1\"]$2[/URL]";
                //string replaced = Regex.Replace(pattern, replacement);
                var matches = regex.Matches(input);
                var result = regex.Replace(input, "[URL href=\"$1\"]$2[/URL]");
                Console.WriteLine(result);
               
                input = Console.ReadLine();
            }
        }
    }
}
