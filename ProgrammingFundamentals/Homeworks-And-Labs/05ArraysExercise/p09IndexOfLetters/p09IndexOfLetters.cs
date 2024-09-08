using System;
using System.Linq;

namespace p09IndexOfLetters
{
    class p09IndexOfLetters
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char[] alphabet = new char[26];
            int indexCounter = 0;

            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alphabet[indexCounter] = letter;
                indexCounter++;
            }

            for (int i = 0; i < word.Length; i++)
            {
                char currentLetter = word[i];
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (currentLetter == alphabet[j])
                    {
                        Console.WriteLine($"{currentLetter} -> {j}");
                    }
                }
            }
        }
    }
}
