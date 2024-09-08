using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p04Weather
{
    class p04Weather
    {
        public static object MessageBox { get; private set; }

        static void Main(string[] args)
        {
            string forecast = Console.ReadLine();
            string pattern = @"([A-Z]{2})([0-9]+\.[0-9]{1,2})([A-Za-z]+)\|";
            List<string> lines = new List<string>();

            while (forecast != "end")
            {
                lines.Add(forecast);
                forecast = Console.ReadLine();
            }

            List<Match> myMatches = new List<Match>();

            foreach (var line in lines)
            {
                MatchCollection matches = Regex.Matches(line, pattern);

                foreach (Match thisMatch in matches)
                {
                    myMatches.Add(thisMatch);
                }
            }

            Dictionary<string,List<string>> weather = new Dictionary<string, List<string>>();

            foreach (Match line in myMatches)
            {
                if (weather.ContainsKey(line.Groups[1].Value) == false)
                {
                    List<string> list = new List<string>();
                    list.Add(line.Groups[2].Value);
                    list.Add(line.Groups[3].Value);
                    weather.Add(line.Groups[1].Value, list);
                }
                else
                {
                    weather[line.Groups[1].Value].Clear();
                    weather[line.Groups[1].Value].Add(line.Groups[2].Value);
                    weather[line.Groups[1].Value].Add(line.Groups[3].Value);
                }
            }

            foreach (var pair in weather.OrderBy(x=>double.Parse(x.Value[0])))
            {
                Console.WriteLine($"{pair.Key} => {double.Parse(pair.Value[0]):f2} => {pair.Value[1]}");
            }
           
        }
    }
}
