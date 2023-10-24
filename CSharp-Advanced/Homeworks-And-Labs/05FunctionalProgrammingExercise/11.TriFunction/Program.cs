using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p13.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Func<string, char[]> funcToCharArr = x => x.ToCharArray();
            Func<char, int> castFunc = y => (int)y;
            Func<string, bool> finalFunc = x => funcToCharArr(x)
               .Select(castFunc)
               .Sum() >= number;

            var names = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .FirstOrDefault(finalFunc);

            Console.WriteLine(names);
        }
    }
}

