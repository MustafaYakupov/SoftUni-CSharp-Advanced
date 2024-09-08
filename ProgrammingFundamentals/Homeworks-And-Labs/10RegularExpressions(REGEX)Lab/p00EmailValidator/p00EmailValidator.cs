using System;
using System.Text.RegularExpressions;

namespace p00EmailValidator
{
    class p00EmailValidator
    {
        static void Main(string[] args)
        {
            var text = @"
            <ul><li><a href=""http://softuni.bg"">SoftUni</a></li></ul> <a
            <a><a><\a>
            <\a>
            ";

            var regex = new Regex(@"<a.+href=""(.+?)"">(.+?)<\/a>");

            var result = regex.Replace(text, "[URL href=\"$1\"]$2[/URL]");

            Console.WriteLine();
            Console.WriteLine(result);
            
        }
    }
}
