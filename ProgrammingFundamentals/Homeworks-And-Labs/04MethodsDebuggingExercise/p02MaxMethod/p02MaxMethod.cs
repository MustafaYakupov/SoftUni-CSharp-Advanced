using System;

namespace p02MaxMethod
{
    class p02MaxMethod
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int result = GetMax(firstNum, secondNum, thirdNum);
            Console.WriteLine(result);
        }

        static int GetMax(int firstNum, int secondNum, int thirdNum)
        {
            if (firstNum > secondNum && firstNum > thirdNum)
            {
                return firstNum;
            }
            else if (secondNum > firstNum && secondNum > thirdNum)
            {
                return secondNum;
            }
            else 
            {
                return thirdNum;
            }
        }
    }
}
