using System;
using System.Linq;

namespace p03SafeManipulation
{
    class p03SafeManipulation
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
           
            while(true)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                if (command[0] == "END")
                {
                    break;
                }

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
                    if (index > arr.Length - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                    arr[index] = "replace";
                    arr = arr.Select(s => s.Replace("replace", replacement)).ToArray();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Console.WriteLine(string.Join(", ", arr));

        }
    }
}
