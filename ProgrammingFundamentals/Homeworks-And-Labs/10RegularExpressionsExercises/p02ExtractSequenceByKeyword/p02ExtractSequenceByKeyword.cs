using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p02ExtractSequenceByKeyword
{
    class p02ExtractSequenceByKeyword
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string[] text = Console.ReadLine().Split(new char[] { '.', '!', '?', }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var regex = new Regex($@"\b{word}\b");
            bool isMatch = false;
            foreach (var sentence in text)
            {
                isMatch = regex.IsMatch(sentence);

                if (isMatch)
                {
                    Console.WriteLine(sentence.Trim());
                }
            }


        }
    }
}
