using System;

namespace p08HouseBuilder
{
    class p08HouseBuilder
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();
            long sbytePrice = 0;
            long intPrice = 0;

            if (Convert.ToInt64(firstInput) > 127)
            {
                try
                {
                    int firstIntNum = int.Parse(firstInput);
                    intPrice = Convert.ToInt64(firstInput) * 10;
                }
                catch { }
               
            }
            if (Convert.ToInt64(secondInput) > 127)
            {
                try
                {
                    int secondIntNum = int.Parse(secondInput);
                    intPrice = Convert.ToInt64(secondInput) * 10;
                }
                catch { }
            }
            if (Convert.ToInt64(firstInput) <= 127)
            {
                try
                {
                    sbyte firstNum = sbyte.Parse(firstInput);
                    sbytePrice = Convert.ToInt64(firstInput) * 4;

                }
                catch { }
              

            }
            if (Convert.ToInt64(secondInput) <= 127)
            {
                try
                {
                    sbyte secondNum = sbyte.Parse(secondInput);
                    sbytePrice = Convert.ToInt64(secondInput) * 4;

                }
                catch { }
            }
            long price = sbytePrice + intPrice;
            Console.WriteLine(price);
        }
    }
}
