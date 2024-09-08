using System;

namespace p03LastKNumbersSumsSequence
{
    class p03LastKNumbersSumsSequence
    {
        static void Main(string[] args)
        {
            long length = long.Parse(Console.ReadLine());
            long count= long.Parse(Console.ReadLine());

            long[] arr = new long[length];
            arr[0] = 1;
            for (long i = 1; i < length; i++)
            {
                long sum = 0;
                long counter = 0;
                for (long j = i; j >= 0; j--)
                {
                    sum += arr[j];
                    counter++;
                    if (counter > count)
                    {
                        break;
                    }
                }
                arr[i] = sum;
            }
            Console.WriteLine(string.Join(" ", arr));
           
        }
    }
}
