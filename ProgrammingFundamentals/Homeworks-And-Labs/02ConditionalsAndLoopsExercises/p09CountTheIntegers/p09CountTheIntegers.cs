using System;

namespace p09CountTheIntegers
{
    class p09CountTheIntegers
    {
        static void Main(string[] args)
        {
            int input = 0;
            int count = 0;
            while (true)
            {
                try
                {
                    count++;
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    break;
                }
            }
            Console.WriteLine(count -1);
          
        }
    }
}
