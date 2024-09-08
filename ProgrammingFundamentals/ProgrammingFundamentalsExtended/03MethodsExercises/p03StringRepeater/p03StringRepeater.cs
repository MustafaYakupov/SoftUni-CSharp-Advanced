using System;

namespace p03StringRepeater
{
    class p03StringRepeater
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            string result = RepeatString(text, count);
            Console.WriteLine(result);
        }

        private static string RepeatString(string text, int count)
        {
            string finalText = string.Empty;
            for (int i = 0; i < count; i++)
            {
                finalText += text;
            }
            return finalText;
        }
    }
}
