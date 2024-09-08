using System;

namespace p08RefactorVolumeOfPyramid
{
    class p08RefactorVolumeOfPyramid
    {
        static void Main(string[] args)
        {
            double length = 0;
            double width = 0;
            double heigth = 0;
            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Heigth: ");
            heigth = double.Parse(Console.ReadLine());
            double v = (length + width + heigth) / 3;
            Console.WriteLine($"Pyramid Volume: { v:F2} ");     
        }
    }
}
