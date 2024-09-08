using System;

namespace p01ReverseString
{
    class p01ReverseString
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();

            var count = 0;
            var index = 0;

            while (true)
            {
                index = text.IndexOf(pattern, index);

                if (index < 0)
                {
                    break;
                }
                else
                {
                    count++;
                    index++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
