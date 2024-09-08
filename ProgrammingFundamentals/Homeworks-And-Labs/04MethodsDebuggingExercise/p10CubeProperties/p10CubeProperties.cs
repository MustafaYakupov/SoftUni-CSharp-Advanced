using System;

namespace p10CubeProperties
{
    class p10CubeProperties
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            if (type == "face")
            {
                double faceDiagonal = FaceDiagonal(side);
                Console.WriteLine($"{faceDiagonal:f2}");
            }
            else if (type == "space")
            {
                double spaceDiagonal = SpaceDiagonal(side);
                Console.WriteLine($"{spaceDiagonal:f2}");
            }
            else if (type == "volume")
            {
                double volume = Volume(side);
                Console.WriteLine($"{volume:f2}");
            }
            else if (type == "area")
            {
                double area = Area(side);
                Console.WriteLine($"{area:f2}");
            }
        }

        static double Area(double side)
        {
            double area = 6 * Math.Pow(side, 2);
            return area;
        }

        static double Volume(double side)
        {
            double volume = Math.Pow(side, 3);
            return volume;
        }

        static double SpaceDiagonal(double side)
        {
            double spaceDiagonal = Math.Sqrt(3 * Math.Pow(side, 2));
            return spaceDiagonal;
        }

        static double FaceDiagonal(double side)
        {
            double faceDiagonal = Math.Sqrt(2 * Math.Pow(side, 2));
            return faceDiagonal;
        }
    }
}
