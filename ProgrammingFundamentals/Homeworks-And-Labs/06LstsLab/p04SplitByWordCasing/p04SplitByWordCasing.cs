using System;
using System.Collections.Generic;
using System.Linq;

namespace p04SplitByWordCasing
{
    class p04SplitByWordCasing
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(",;:.!()\"'\\/[] ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> upperCase = new List<string>();
            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();


            foreach (var word in text)
            {
                if (IsUpperWord(word))
                {
                    upperCase.Add(word);
                }
                else if (IsLowerWord(word))
                {
                    lowerCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));

        }
        static bool IsUpperWord(string word)
        {
            foreach (char symbol in word)
            {
                if (symbol < 'A' || symbol > 'Z')
                {
                    return false;
                }
            }
            return true;
        }
        static bool IsLowerWord(string word)
        {
            foreach (char symbol in word)
            {
                if (symbol < 'a' || symbol > 'z')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
