using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string nameInput = Console.ReadLine();
                names.Add(nameInput);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
