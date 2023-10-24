namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using StreamReader reader = new(inputFilePath);
            
            string line = string.Empty;
            int count = 0;

            while (line != null) 
            {
                line = reader.ReadLine();

                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplacedSymbols(line);
                    string reversedWords = ReverseWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }

                count++;
            }
            
            return sb.ToString().TrimEnd();
        }

        private static string ReplacedSymbols(string line)
        {
            StringBuilder sb = new(line);

            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (var symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }

        private static string ReverseWords(string words)
        {
            string[] reversedWords = words
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(" ", reversedWords);
        }
    }
}
