using System;

namespace p05WordInPlural
{
    class p05WordInPlural
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            if (word.EndsWith("y") == true)
            {
                word = word.Replace("y", "ies");
            }
            else if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh") || word.EndsWith("x") || word.EndsWith("z"))
            {
                word = word += "es";
            }
            else
                word = word += "s";
           
            Console.WriteLine(word);
        }
    }
}
