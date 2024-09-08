using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p04StarEnigma
{
    class p04StarEnigma
    {
        static void Main(string[] args)
        {
            string pattern = @"([^@:!\->]*)@([A-Za-z]+)([^@:!\->]*):([0-9]+)([^@:!\->]*)!([AD])!([^@:!\->]*)->([0-9]+)([^@:!\->]*)";
            int n = int.Parse(Console.ReadLine());

            List<string> messages = new List<string>();
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                messages.Add(string.Join("", GetMessage(message)));
            }

            foreach (var message in messages)
            {
                var matches = Regex.Matches(message, pattern);

                foreach (Match m in matches)
                {
                    string name = m.Groups[2].ToString();
                    string population = m.Groups[4].ToString();
                    string attackType = m.Groups[6].ToString();
                    string soldierCount = m.Groups[8].ToString();

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(name);
                    }
                }
            }
            
            if (attackedPlanets.Count <= 0)
            {
                Console.WriteLine("Attacked planets: 0");
            }
            else
            {
                Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

                foreach (var planet in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            if (destroyedPlanets.Count <= 0)
            {
                Console.WriteLine("Destroyed planets: 0");
            }
            else
            {
                Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

                foreach (var planet in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }

        private static List<string> GetMessage(string message)
        {
            int count = 0;
            List<char> decripted = new List<char>();
            char[] encrypted = message.ToCharArray();
            List<string> messages = new List<string>();


            foreach (var symbol in encrypted)
            {
                if (symbol == 'S' || symbol == 'T' || symbol == 'A' || symbol == 'R' || symbol == 's' || symbol == 't' || symbol == 'a' || symbol == 'r')
                {
                    count++;
                }
            }

            foreach (var element in encrypted)
            {
                decripted.Add((char)(element - count));
            }
            messages.Add(string.Join("", decripted).ToString());

            return messages;
        }
    }
}
