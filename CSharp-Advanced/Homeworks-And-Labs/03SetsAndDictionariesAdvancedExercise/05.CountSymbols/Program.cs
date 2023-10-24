using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            Dictionary<char, int> resultDict = new Dictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!resultDict.ContainsKey(symbol))
                {
                    resultDict.Add(symbol, 0);
                }

                resultDict[symbol]++;
            }

            foreach (var kvp in resultDict.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
