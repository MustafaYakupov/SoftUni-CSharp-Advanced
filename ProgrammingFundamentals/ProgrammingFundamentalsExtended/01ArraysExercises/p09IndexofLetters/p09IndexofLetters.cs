using System;
using System.Collections.Generic;
using System.Linq;

namespace p09IndexofLetters
{
    class p09IndexofLetters
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            var alphabet = new List<char>();
            int index = 0;
            
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabet.Add(i);
                index++;
            }
            foreach (var num in word)
            {
                Console.WriteLine($"{num} -> {alphabet.IndexOf(num)}");
            }
        }
    }
}
