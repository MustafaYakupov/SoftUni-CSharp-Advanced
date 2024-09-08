using System;

namespace p19TheaThePhotographer
{
    class p19TheaThePhotographer
    {
        static void Main(string[] args)
        {
            double pictures = double.Parse(Console.ReadLine());
            double filterTimePerPic = double.Parse(Console.ReadLine());
            double usefulPicturesPercentage = double.Parse(Console.ReadLine());
            double uploadTimePerPic = double.Parse(Console.ReadLine());
            double usefulPictures = Math.Ceiling(pictures * (usefulPicturesPercentage / 100));
            double filteringTime = pictures * filterTimePerPic;
            double uploadingTime = usefulPictures * uploadTimePerPic;
            double totalTime = filteringTime + uploadingTime;
            TimeSpan newTime = TimeSpan.FromSeconds((ulong)totalTime);
            //double daysNeeded = (totalTime / 86400);
            //double hoursNeeded = (totalTime / 3600);
            //double minutesNeeded = (totalTime / 60) % 60;
            //double secondsNeeded = totalTime % 60;

            Console.WriteLine("{0:d1}:{1:d2}:{2:d2}:{3:d2}", newTime.Days, newTime.Hours, newTime.Minutes, newTime.Seconds);
        }
    }
}
