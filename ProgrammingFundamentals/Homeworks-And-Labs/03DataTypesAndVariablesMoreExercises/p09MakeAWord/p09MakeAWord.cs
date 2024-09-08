using System;

namespace p09MakeAWord
{
    class p09MakeAWord
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string word = "";
            for (int i = 1; i <= lines; i++)
            {
                char character = char.Parse(Console.ReadLine());
                word += character;
            }
            Console.WriteLine($"The word is: {word}");
        }
    }
}
