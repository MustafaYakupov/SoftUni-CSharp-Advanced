using System;

namespace p14MagicLetter
{
    class p14MagicLetter
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            for (char i = first; i <= second; i++)
            {
                for (char s = first; s <= second; s++)
                {
                    for (char k = first; k <= second; k++)
                    {
                        if (i == third || s == third || k == third)
                        {
                            continue;
                        }
                        else
                        {
                            Console.Write($"{i}{s}{k} ");
                        }
                    }
                }
            }
        }
    }
}
