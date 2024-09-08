using System;
using System.Linq;

namespace p09JumpAround
{
    class p09JumpAround
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int currentIndex = 0;
            int nextIndex;
            int sum = 0;

            while (true)
            {
                sum += arr[currentIndex];

                if (currentIndex + arr[currentIndex] > arr.Length - 1)
                {
                    if (currentIndex - arr[currentIndex] < 0)
                    {
                        break;
                    }
                    else
                   {
                        nextIndex = currentIndex - arr[currentIndex];
                        currentIndex = nextIndex;
                    }
                }
                else
                {
                    nextIndex = currentIndex + arr[currentIndex];
                    currentIndex = nextIndex;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
