using System;

namespace p05FibonacciNumbers
{
    class p05FibonacciNumbers
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            if (number == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(Fibonacci(number));
            }
        }

        static long Fibonacci(long number)
        {
            long fib1 = 0;
            long fib2 = 1;
            long fibNext = 1;

            for (long i = 1; i <= number; i++)
            {
                fibNext = fib1 + fib2;
                fib1 = fib2;
                fib2 = fibNext ;
            }
            return fibNext;
        }
    }
}
