namespace _01.FoodFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void Main(string[] args)
        {
           //Queue Peek  dequeu enquee 
           //Stack  Pop

            char[] vowels = Console.ReadLine().ToCharArray();
            char[] consonants = Console.ReadLine().ToCharArray();

            List<char> lettersToMatch = new List<char>() { 'p', 'e', 'a', 'r', 'f', 'l', 'o', 'u', 'k', 'i', 'v' };
            List<char> matchedLetters = new List<char>();
            List<string> matchedWords = new List<string>();

            Queue<char> queueOfVowels = new Queue<char>(vowels);
            Stack<char> stackOfConsonants = new Stack<char>(consonants);

            while (stackOfConsonants.Any())
            {
                char vowel = queueOfVowels.Dequeue();
                queueOfVowels.Enqueue(vowel);
                char consonant = stackOfConsonants.Pop();

                if (lettersToMatch.Contains(vowel))
                {
                    matchedLetters.Add(vowel);
                }

                if (lettersToMatch.Contains(consonant))
                {
                    matchedLetters.Add(consonant);
                }
            }

            if (matchedLetters.Contains('p') 
                && matchedLetters.Contains('e')
                && matchedLetters.Contains('a')
                && matchedLetters.Contains('r')
                )
            {
                matchedWords.Add("pear");
            }

            if (matchedLetters.Contains('f')
                && matchedLetters.Contains('l')
                && matchedLetters.Contains('o')
                && matchedLetters.Contains('u')
                && matchedLetters.Contains('r')
                )
            {
                matchedWords.Add("flour");
            }

            if (matchedLetters.Contains('p')
                && matchedLetters.Contains('o')
                && matchedLetters.Contains('r')
                && matchedLetters.Contains('k')
                )
            {
                matchedWords.Add("pork");
            }

            if (matchedLetters.Contains('o')
                && matchedLetters.Contains('l')
                && matchedLetters.Contains('i')
                && matchedLetters.Contains('v')
                && matchedLetters.Contains('e')
                )
            {
                matchedWords.Add("olive");
            }

            Console.WriteLine($"Words found: {matchedWords.Count}");

            Console.WriteLine(String.Join(Environment.NewLine, matchedWords));
        }
    }
}