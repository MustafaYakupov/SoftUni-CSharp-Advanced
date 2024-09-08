using System;

namespace p06BarcodeGenerator
{
    class p06BarcodeGenerator
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int a1 = (a / 1000) % 10;
            int a2 = (a / 100) % 10;
            int a3 = (a / 10) % 10;
            int a4 = (a / 1) % 10;

            int b1 = (b / 1000) % 10;
            int b2 = (b / 100) % 10;
            int b3 = (b / 10) % 10;
            int b4 = (b / 1) % 10;

            int barcode;

            for (int i = a1; i <= b1; i++)
            {
                for (int k = a2; k <= b2; k++)
                {
                    for (int j = a3; j <=b3; j++)
                    {
                        for (int g = a4; g <= b4; g++)
                        {
                            if (i % 2 != 0 && k % 2 != 0 && j % 2 != 0 && g % 2 != 0)
                            {
                                barcode = i * 1000 + k * 100 + j * 10 + g;
                                if (barcode >= a && barcode <= b)
                                {
                                    Console.Write($"{barcode} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
