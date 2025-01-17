﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace p01Phonebook
{
    class p01Phonebook
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            string[] commands = Console.ReadLine().Split(' ').ToArray();

            while (commands[0] != "END")
            {
                if (commands[0] == "A")
                {
                    if (!phonebook.ContainsKey(commands[1]))
                    {
                        phonebook.Add(commands[1], commands[2]);
                    }
                    else
                    {
                        phonebook[commands[1]] = commands[2];
                    }
                }
                else if (commands[0] == "S")
                {
                    if (!phonebook.ContainsKey(commands[1]))
                    {
                        Console.WriteLine($"Contact {commands[1]} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{commands[1]} -> {phonebook[commands[1]]}");
                    }

                }
                else if (commands[0] == "ListAll")
                {
                    foreach (var pair in phonebook.OrderBy(x => x.Key))
                    {
                        Console.WriteLine(string.Join(" -> ",pair.Key, pair.Value ));
                    }
                    
                }
                commands = Console.ReadLine().Split(' ').ToArray();
            }
        }
    }
}
