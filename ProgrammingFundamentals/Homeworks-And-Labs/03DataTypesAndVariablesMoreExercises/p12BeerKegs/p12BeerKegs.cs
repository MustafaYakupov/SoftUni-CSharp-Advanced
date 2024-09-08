using System;

namespace p12BeerKegs
{
    class p12BeerKegs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double kegVolume = 0;
            double maxVolume = 0;
            int iteration = 0;
            string maxVolumeModel="";
            for (int i = 1; i <= 3*n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                kegVolume = Math.PI * Math.Pow(radius, 2) * height;

                if (kegVolume > maxVolume)
                {
                    maxVolume = kegVolume;
                    maxVolumeModel = model;
                    iteration = i;
                }
                else
                {
                    continue;
                }
                
            }
            Console.WriteLine(maxVolumeModel);
        }
    }
}
