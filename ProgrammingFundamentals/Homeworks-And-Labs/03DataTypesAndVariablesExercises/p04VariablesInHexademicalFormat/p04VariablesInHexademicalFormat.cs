using System;

namespace p04VariablesInHexademicalFormat
{
    class p04VariablesInHexademicalFormat
    {
        static void Main(string[] args)
        {
            string hexValue = Console.ReadLine();
            int decValue = Convert.ToInt32(hexValue, 16);
            Console.WriteLine(decValue);
        }
    }
}
