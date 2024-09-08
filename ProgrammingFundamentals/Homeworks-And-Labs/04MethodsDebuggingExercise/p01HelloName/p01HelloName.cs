using System;

namespace p01HelloName
{
    class p01HelloName
    {
        static void Main(string[] args)
        {
            PrintName();
        }

        static void PrintName()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
