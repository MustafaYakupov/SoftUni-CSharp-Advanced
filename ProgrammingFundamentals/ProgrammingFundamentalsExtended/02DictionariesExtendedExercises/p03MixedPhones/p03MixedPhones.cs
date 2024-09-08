using System;
using System.Collections.Generic;

namespace p03MixedPhones
{
    class p03MixedPhones
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var phonebook = new SortedDictionary<string, long>();

            while (input[0] != "Over")
            {
                bool isNumber = long.TryParse(input[0], out long num);
                string name;
                long number;

                if (isNumber)
                {
                    name = input[2];
                    number = long.Parse(input[0]);
                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name, number);
                    }
                    else
                    {
                        phonebook[name] = number;
                    }
                }
                else
                {
                    name = input[0];
                    number = long.Parse(input[2]);
                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name, number);
                    }
                    else
                    {
                        phonebook[name] = number;
                    }
                }
                input = Console.ReadLine().Split();
            }
            foreach (var contact in phonebook)
            {
                Console.WriteLine($"{contact.Key} -> {contact.Value}");
            }
        }
    }
}
