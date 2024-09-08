using System;
using System.Linq;

namespace p03TextFilter
{
    class p03TextFilter
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(new[] { ", ", }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = Console.ReadLine();

            int index = 0;

            foreach (var word in banWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
}
