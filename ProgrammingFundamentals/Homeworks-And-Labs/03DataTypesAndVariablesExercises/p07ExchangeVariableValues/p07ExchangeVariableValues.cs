using System;

namespace p07ExchangeVariableValues
{
    class p07ExchangeVariableValues
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine($"Before:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            int c = b;
            b = a;
            a = c;
            Console.WriteLine($"After:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }
    }
}
