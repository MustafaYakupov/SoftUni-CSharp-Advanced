using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p01ForceBook
{
    class p01ForceBook
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(.+)(\s)(\||->)(\s)(.+)";

            var forces = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                var matches = Regex.Match(input, pattern);

                if (matches.Groups[3].ToString() == "|")
                {
                    string side = matches.Groups[1].ToString();
                    string user = matches.Groups[5].ToString();

                    if (forces.Values.Any(x=>x.Contains(user)) == false)
                    {
                        if (forces.ContainsKey(side) == false)
                        {
                            forces.Add(side, new List<string>() { user });
                        }
                        else
                        {
                            forces[side].Add(user);
                        }
                    }
                }
                else if (matches.Groups[3].ToString() == "->")
                {
                    string user = matches.Groups[1].ToString();
                    string side = matches.Groups[5].ToString();

                    if (forces.ContainsKey(side) == false)
                    {
                        forces.Add(side, new List<string>());
                    }

                    if (forces.Values.Any(x => x.Contains(user)))
                    {
                        foreach (var pair in forces)
                        {
                            if (pair.Value.Contains(user))
                            {
                                forces[pair.Key].Remove(user);
                            }
                        }
                    }

                    forces[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
                input = Console.ReadLine();
            }

            foreach (var pair in forces.OrderByDescending(x => x.Value.Count).ThenBy(x=>x.Key))
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {pair.Key}, Members: {pair.Value.Count}");

                    foreach (var user in pair.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
