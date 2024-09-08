using System;

namespace p09RefactorSpeciallNumber
{
    class p09RefactorSpeciallNumber
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = 0;
            bool isSpecial = false;
            for (int i = 1; i <= count; i++)
            {
                num = i;
                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {isSpecial}");
                sum = 0;
                i = num;
            }
              
               
        }

    }
}

