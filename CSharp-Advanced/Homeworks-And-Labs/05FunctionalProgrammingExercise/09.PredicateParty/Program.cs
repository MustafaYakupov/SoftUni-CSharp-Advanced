using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }
                string[] tokens = input.Split();

                string command = tokens[0];
                string filterCommand = tokens[1];
                string criteria = tokens[2];

                if (command == "Remove")
                {
                    guests.RemoveAll(GetPredicate(filterCommand, criteria));
                }
                else if (command == "Double")
                {
                    List<string> guestsToAdd = guests.FindAll(GetPredicate(filterCommand, criteria));

                    foreach (var name in guestsToAdd)
                    {
                        int index = guests.IndexOf(name);

                        guests.Insert(index + 1, name);
                    }
                }

            }

            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            if (filter == "StartsWith")
            {
                return p => p.StartsWith(value);
            }
            else if (filter == "EndsWith")
            {
                return p => p.EndsWith(value);
            }
            else if (filter == "Length")
            {
                return p => p.Length == int.Parse(value);
            }

            return null;
        }
    }
}
