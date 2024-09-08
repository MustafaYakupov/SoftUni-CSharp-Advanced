using System;
using System.Collections.Generic;
using System.Linq;

namespace p04FixEmails
{
    class p04FixEmails
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mailBox = new Dictionary<string, string>();
            string input = Console.ReadLine();
            string name = "";
            string mail = "";

            while (input != "stop")
            {
                name = input;
                mail = Console.ReadLine();

                if (!mailBox.ContainsKey(input))
                {
                    mailBox.Add(name, mail);
                }
                else
                {
                    mailBox[name] += mail;
                }

                input = Console.ReadLine();
            }
            foreach (var pair in mailBox.Where(x => !x.Value.EndsWith(".uk") && !x.Value.EndsWith(".us")))
            {
                Console.WriteLine(string.Join(" -> ", pair.Key, pair.Value));
            }
        }
    }
}
