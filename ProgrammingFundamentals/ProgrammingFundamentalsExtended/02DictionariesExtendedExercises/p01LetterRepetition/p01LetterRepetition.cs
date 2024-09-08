using System;
using System.Collections.Generic;

namespace p01LetterRepetition
{
    class p01LetterRepetition
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            
            var count = new Dictionary<char, int>();
            
            foreach (char letter in letters)
            {
                if (!count.ContainsKey(letter))
                {
                    count[letter] = 1;
                }
                else
                {
                    count[letter]++;
                }
            }
            foreach (var num in count)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
