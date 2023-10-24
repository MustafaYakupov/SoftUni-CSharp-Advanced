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

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (command == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else 
                {
                    filters.Remove(filter + value);
                }

            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine(String.Join(" ", guests));
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            if (filter == "Starts with")
            {
                return p => p.StartsWith(value);
            }
            else if (filter == "Ends with")
            {
                return p => p.EndsWith(value);
            }
            else if (filter == "Length")
            {
                return p => p.Length == int.Parse(value);
            }
            else if (filter == "Contains")
            {
                return p => p.Contains(value);
            }

            return null;
        }
    }
}
