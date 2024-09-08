using System;
using System.Collections.Generic;
using System.Linq;

namespace p02ChangeList
{
    class p02ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split(' ').ToArray();

            while (commands[0] != "Odd" && commands[0] != "Even")
            {
                if (commands[0] == "Delete")
                {
                    int n = int.Parse(commands[1]);
                    numbers.RemoveAll(num => num == n);
                }
                else if (commands[0] == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);
                    numbers.Insert(index, element);
                }
                commands = Console.ReadLine().Split(' ').ToArray();
            }
            if (commands[0] == "Odd")
            {
               numbers.RemoveAll(x => x % 2 == 0);
            }
            else if (commands[0] == "Even")
            {
               numbers.RemoveAll(x => x % 2 != 0);
            }
            Console.WriteLine(string.Join(" ", numbers));


            //List<int> inputList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            //string inputLine = Console.ReadLine();
            //
            //
            //while (inputLine != "Odd" && inputLine != "Even")
            //{
            //    string[] command = inputLine.Split(' ').ToArray();
            //    if (command[0] == "Delete")
            //    {
            //        int number = int.Parse(command[1]);
            //
            //        for (int i = 0; i < inputList.Count; i++)
            //        {
            //            inputList.Remove(number);
            //        }
            //    }
            //    else if (command[0] == "Insert")
            //    {
            //        int element = int.Parse(command[1]);
            //        int index = int.Parse(command[2]);
            //        inputList.Insert(index, element);
            //    }
            //    inputLine = Console.ReadLine();
            //}
            //if (inputLine == "Odd")
            //{
            //    foreach (var element in inputList)
            //    {
            //        if (element % 2 != 0 )
            //        {
            //            Console.Write(element +" ");
            //        }
            //    }
            //}
            //else if (inputLine == "Even")
            //{
            //    foreach (var element in inputList)
            //    {
            //        if (element % 2 == 0)
            //        {
            //            Console.Write(element + " ");
            //        }
            //    }
            //}
        }
    }
}
