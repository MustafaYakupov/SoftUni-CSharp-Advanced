using System;

namespace p05SpecialNumbers
{
    class p05SpecialNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            
            for (int i = 1; i <= num; i++)
            {
                if (i % 10 + i / 10 == 5 || i % 10 + i / 10 == 7 || i % 10 + i / 10 == 11)
                {
                    Console.WriteLine("{0} -> True", i);
                }
                else
                {
                    Console.WriteLine("{0} -> False", i);
                }
            }


        }
    }
    
}
