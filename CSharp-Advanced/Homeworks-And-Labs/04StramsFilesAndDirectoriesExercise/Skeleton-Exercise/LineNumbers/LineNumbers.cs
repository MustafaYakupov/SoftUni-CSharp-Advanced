namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new();

            string[] lines = File.ReadAllLines(inputFilePath);

            int linesCounter = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                int letterCount = lines[i].Count(ch => char.IsLetter(ch));
                int marksCount = lines[i].Count(ch => char.IsPunctuation(ch));

                sb.Append($"Line {i + 1}: {lines[i]} ({letterCount})({marksCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}
