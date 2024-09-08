using System;

namespace p04DrawFilledSquere
{
    class p04DrawFilledSquere
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            HeaderRow(input);
            PrintMiddleRow(input);
            HeaderRow(input);
        }

        static void HeaderRow(int input)
        {
            
            Console.WriteLine("{0}", new string('-', input * 2));
        }

        static void PrintMiddleRow(int input)
        {
            
            Console.Write('-');
            for (int i = 1; i < input; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine('-');
        }
    }
}
