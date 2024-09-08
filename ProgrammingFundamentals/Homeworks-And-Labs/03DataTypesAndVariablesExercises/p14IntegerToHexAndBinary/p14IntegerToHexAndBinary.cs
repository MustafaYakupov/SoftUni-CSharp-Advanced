using System;

namespace p14IntegerToHexAndBinary
{
    class p14IntegerToHexAndBinary
    {
        static void Main(string[] args)
        {
            int decimalNum = int.Parse(Console.ReadLine());
            string hexadecimalNum = decimalNum.ToString("X");
            string binaryNum = Convert.ToString(decimalNum, 2);
            Console.WriteLine(hexadecimalNum);
            Console.WriteLine(binaryNum);
        }
    }
}
