using System;
using System.Collections.Generic;
using System.Linq;

namespace p05ShortWordsSorted
{
    class p05ShortWordsSorted
    {
        static void Main(string[] args)
        {
             Console.WriteLine(string.Join(", ", Console.ReadLine()
             .ToLower()
             .Split(". , : ; ( ) [ ] \" ' \\ / ! ? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
             .Distinct()
             .Where(x => x.Length < 5)
             .OrderBy(x => x)
             .ToList()));
        }
    }
}
