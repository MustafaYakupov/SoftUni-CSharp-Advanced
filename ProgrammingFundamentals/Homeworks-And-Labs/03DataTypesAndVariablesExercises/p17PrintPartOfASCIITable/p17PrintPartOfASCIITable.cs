using System;

namespace p17PrintPartOfASCIITable
{
    class p17PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                Console.Write((char)(i) + " ");
            }
        }
    }
}
