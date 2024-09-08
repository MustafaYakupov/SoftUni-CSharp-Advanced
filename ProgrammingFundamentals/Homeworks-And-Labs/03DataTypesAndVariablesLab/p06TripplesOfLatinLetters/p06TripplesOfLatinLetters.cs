using System;

namespace p06TripplesOfLatinLetters
{
    class p06TripplesOfLatinLetters
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (char a = 'a'; a < 'a' + num ; a++)
            {
                for (char b = 'b'; b < 'b' + num; b++)
                {
                    for (char c = 'c'; c < 'c' + num; c++)
                    {
                       
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
