using System;
using System.Text.RegularExpressions;

namespace p01Censorship
{
    class p01Censorship
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string sentence = Console.ReadLine();
            
            var regex = new Regex($@"{ word }");
            var matches = regex.Match(sentence);
           
            var result = regex.Replace(sentence, new string('*', word.Length));
            Console.WriteLine(result);
        }
    }
}
