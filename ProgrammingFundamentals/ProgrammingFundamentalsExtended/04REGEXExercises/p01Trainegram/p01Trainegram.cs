using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace p01Trainegram
{
    class p01Trainegram
    {
        static void Main(string[] args)
        {
            string pattern = @"^(<\[[^A-Za-z\d]*?\]\.)(\.\[[A-Za-z\d]*\]\.)*$";
            string input = Console.ReadLine();
            List<Match> list = new List<Match>();

            while (input != "Traincode!")
            {
                string message = input;

                if (Regex.IsMatch(message, pattern))
                {
                    list.Add(Regex.Match(message, pattern));
                }

                input = Console.ReadLine();
            }

            foreach (Match m in list)
            {
                Console.WriteLine(m.Value);
            }
        }
    }
}
