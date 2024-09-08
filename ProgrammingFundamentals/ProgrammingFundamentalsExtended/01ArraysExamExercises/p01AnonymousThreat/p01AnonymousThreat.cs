using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01AnonymousThreat
{
    class p01AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];

                if (command == "3:1")
                {
                    break;
                }

                int startIndex = int.Parse(commands[1]);
                int endIndex = int.Parse(commands[2]);
                string concatWord = string.Empty;

                if (endIndex > input.Count - 1 || endIndex < 0)
                {
                    endIndex = input.Count - 1;
                }
                if (startIndex < 0 || startIndex > input.Count)
                {
                    startIndex = 0;
                }

                if (command == "merge")
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatWord += input[i];
                    }
                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    input.Insert(startIndex, concatWord);

                }
                else if (command == "divide")
                {
                    List<string> divided = new List<string>();
                    int partitions = int.Parse(commands[2]);
                    string word = input[startIndex];

                    input.RemoveAt(startIndex);
                    int letters = word.Length / partitions;
                    

                    for (int i = 0; i < partitions; i++)
                    {
                        divided.Add(word.Substring(0, letters));
                        word = word.Remove(0, letters);
                    }

                    divided[divided.Count - 1] = divided[divided.Count - 1] + word;
                    input.InsertRange(startIndex, divided);
                }


            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}