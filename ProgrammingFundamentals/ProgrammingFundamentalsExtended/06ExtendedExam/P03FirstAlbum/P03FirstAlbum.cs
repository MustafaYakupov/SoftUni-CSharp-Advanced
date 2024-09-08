using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P03FirstAlbum
{
    class P03FirstAlbum
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"";
            int count = 0;

            List<string> songs = new List<string>();

            while (text != "Rock on!")
            {
                var matches = Regex.Matches(text, pattern);

                foreach (Match m in matches)
                {
                    string name = "";
                    string lyrics = "";
                    string length = "";


                    count++;
                    if (count <= 4)
                    {
                        songs.Add($"");
                    }
                    else
                    {
                        break;
                    }
                }

                text = Console.ReadLine();
            }
        }
    }
}
