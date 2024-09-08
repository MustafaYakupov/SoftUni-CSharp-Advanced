using System;

namespace p05BooleanVariable
{
    class p05BooleanVariable
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool output = (Convert.ToBoolean(input));
            if (output == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
