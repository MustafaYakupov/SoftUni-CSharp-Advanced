using System;

namespace p01HelloName
{
    class p01HelloName
    {
        static void Main(string[] args)
        {
            GetName();
        }

        static void GetName()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
