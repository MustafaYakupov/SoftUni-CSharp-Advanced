using System;

namespace p02MinMethod
{
    class p02MinMethod
    {
        static void Main(string[] args)
        {
            int aaa = int.Parse(Console.ReadLine());
            int bbb = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int min = GetMin(GetMin(aaa, bbb), c);
            Console.WriteLine(min);
        }

        static int GetMin(int a, int b)
        {
            int min = (Math.Min(a,b));
            return min;
        }
    }
}
