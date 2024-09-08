using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p06ValidUsernames
{
    class p06ValidUsernames
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] name = input.Split(new char[] { ' ', '/', '\\', '(', ')' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            string pattern = @"(^|(?<=\s))([A-Za-z][\w]{2,24})";

            List<string> userNames = new List<string>();

            foreach (var user in name)
            {
                if (Regex.IsMatch(user, pattern) && user.Length >= 3 && user.Length <= 25) 
                {
                    userNames.Add(user);
                }
            }
            int sum = 0;
            int maxSum = 0;
            int position = 0;
            
            for (int i = 0; i < userNames.Count-1; i++)
            {
                sum = userNames[i].Length + userNames[i+1].Length;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    position = i;
                }

            }
            Console.WriteLine(userNames[position]);
            Console.WriteLine(userNames[position+1]);
        }
    }
}
