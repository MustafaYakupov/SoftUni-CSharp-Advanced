using System;
using System.Linq;

namespace p02ManipulateArray
{
    class p02ManipulateArray
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
            int lines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                if (command[0] == "Reverse")
                {
                    arr = arr.Reverse().ToArray();
                }
                else if (command[0] == "Distinct")
                {
                    arr = arr.Distinct().ToArray();
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    string replacement = command[2];
                    arr[index] = "replace";
                    arr = arr.Select(s => s.Replace("replace", replacement)).ToArray();
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
