using System;
using System.Numerics;

namespace p14FactorialTrailingZeroes
{
    class p14FactorialTrailingZeroes
    {
        static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            BigInteger factorial = Factorial(input);
            BigInteger countZeroes = 0;

            for (int i = 0; i < factorial.ToString().Length; i++)
            {
                if (factorial % 10 == 0)
                {
                    countZeroes++;
                    factorial /= 10;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(countZeroes);
        }

        static BigInteger Factorial(BigInteger input)
        {
            BigInteger factorial = 1;
            for (BigInteger i = 0; i < input; i++)
            {
                factorial *= (input - i);
            }
            return factorial;
        }
    }
}
