using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p03CameraView
{
    class p03CameraView
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int toSkip = numbers[0];
            int toTake = numbers[1];
            string text = Console.ReadLine();

            //string pattern = @"\|<([\w]{" + toSkip + @"})([\w]{0," + toTake + @"})";
            string pattern = $@"\|<([\w]{{{toSkip}}})([\w]{{0,{toTake}}})";

            var matches = Regex.Matches(text, pattern);
          
            var result = matches.Cast<Match>().Select(x => x.Groups[2].Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", result));


        }
    }
}
