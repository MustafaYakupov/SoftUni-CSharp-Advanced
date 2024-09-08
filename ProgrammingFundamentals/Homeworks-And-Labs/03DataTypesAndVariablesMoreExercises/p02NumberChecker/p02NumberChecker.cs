using System;

namespace p02NumberChecker
{
    class p02NumberChecker
    {
        static void Main(string[] args)
        {
            double input;

            try
            {
                input = long.Parse(Console.ReadLine());
                Console.WriteLine("integer");
                
                
            }
            catch
            {
                Console.WriteLine("floating-point");
            }
            

        }
    }
}
