namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCountDict = new Dictionary<string, int>();

            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        string[] words = wordReader.ReadLine().Split(' ').ToArray();

                        List<string> textToCheck = new List<string>();

                        string text = string.Empty;

                        while (textReader.EndOfStream == false)
                        {
                             text = textReader.ReadToEnd();
                            textToCheck = text.Split(new char[] { ',', '.', '!', '?', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        }
                        
                        foreach (var word in words)
                        {
                            foreach (var item in textToCheck)
                            {
                                if (string.Equals(word.ToLower(), item.ToLower()))
                                {
                                    if (!wordsCountDict.ContainsKey(word))
                                    {
                                        wordsCountDict.Add(word, 0);
                                    }
                                 
                                    wordsCountDict[word]++;
                                }
                            }
                        }

                        foreach (var kvp in wordsCountDict.OrderBy(x=>x.Value).Reverse())
                        {
                            string currentWord = kvp.Key;
                            int currentWordCount = kvp.Value;

                            writer.WriteLine($"{currentWord} - {currentWordCount}");
                        }
                    }
                }
            }
        }
    }
}
