using System;
using System.Numerics;

namespace p13Factorial
{
    class p13Factorial
    {
        static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());


            BigInteger factorial = Factorial(input);
            
            Console.WriteLine(factorial);
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
