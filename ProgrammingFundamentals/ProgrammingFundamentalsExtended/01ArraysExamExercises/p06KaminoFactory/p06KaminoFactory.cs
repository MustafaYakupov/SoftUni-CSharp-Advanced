using System;
using System.Collections.Generic;
using System.Linq;

namespace p06KaminoFactory
{
    class p06KaminoFactory
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();


            var currentSequence = new List<int>();
            var longestSequence = new List<int>();
            var countOf1 = 0;
            var bestCount = 0;
            var sampleCount = 0;
            var bestSampleCount = 0;
            var startIndex = 0;
            var bestIndex = 0;

            while (input != "Clone them!")
            {
                List<string> sequence = input.Split(new[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Where(x => int.Parse(x) == 0 || int.Parse(x) == 1).ToList();

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (int.Parse(sequence[i]) == 1)
                    {
                        countOf1++;
                        sampleCount++;
                        startIndex = i;

                        currentSequence.Clear();
                        foreach (var item in sequence)
                        {
                            startIndex = i;
                            currentSequence.Add(int.Parse(item));
                        }

                        if (currentSequence.Count > longestSequence.Count)
                        {
                            longestSequence.Clear();
                            foreach (var item in currentSequence)
                            {
                                longestSequence.Add(item);
                                bestSampleCount = sampleCount;
                            }

                            startIndex = 0;
                            countOf1 = 0;
                            sampleCount = 0;

                        }
                        else if (currentSequence.Count == longestSequence.Count)
                        {
                            if (bestIndex > startIndex)
                            {
                                longestSequence.Clear();
                                foreach (var item in currentSequence)
                                {
                                    longestSequence.Add(item);
                                    bestSampleCount = sampleCount;
                                }
                            }
                            else if (countOf1 > bestCount)
                            {
                                bestSampleCount = sampleCount;
                                bestCount = countOf1;
                                if (startIndex < bestIndex)
                                {
                                    bestIndex = startIndex;
                                }
                                longestSequence.Clear();
                                foreach (var item in currentSequence)
                                {
                                    longestSequence.Add(item);
                                }
                            }
                            startIndex = 0;
                            countOf1 = 0;
                            sampleCount = 0;

                        }

                    }
                    else
                    {
                        startIndex = 0;
                        countOf1 = 0;
                        sampleCount = 0;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSampleCount} with sum: {longestSequence.Sum()}.");
            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}
