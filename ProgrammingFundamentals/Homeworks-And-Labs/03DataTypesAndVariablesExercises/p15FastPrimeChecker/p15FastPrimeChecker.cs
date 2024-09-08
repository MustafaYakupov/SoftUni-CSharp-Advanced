using System;

namespace p15FastPrimeChecker
{
    class p15FastPrimeChecker
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i<= num; i++)
{
                bool isItPrime = true;
                for (int k = 2; k <= Math.Sqrt(i); k++)
{
                    if (i % k == 0)
                    {
                        isItPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isItPrime}");
                
            }
        }
    }
}
