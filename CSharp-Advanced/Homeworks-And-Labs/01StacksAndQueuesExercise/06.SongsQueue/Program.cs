using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] songs = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> songsQueue = new Queue<string>(songs);

            while (true)
            {

                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                List<string> commands = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

                if (commands[0] == "Add")
                {
                    string songToAdd = String.Join(" ", commands.Skip(1));
                    if (!songsQueue.Contains(songToAdd))
                    {
                        songsQueue.Enqueue(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }
                else if (commands[0] == "Play")
                {
                    

                    songsQueue.Dequeue();
                }
                else if (commands[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
        }
    }
}
