using System;
using System.Text.RegularExpressions;

namespace p02Emailme
{
    class p02Emailme
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            var regex = new Regex(@"\b(.+)\b@(.+)");
            var matches = regex.Match(email);

            var before = matches.Groups[1];
            var after = matches.Groups[2];
            double subtraction = before.Length - after.Length;

            if (subtraction >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
