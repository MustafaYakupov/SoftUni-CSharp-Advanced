using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09.TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            string text = "";

            Stack<char> charStack = new Stack<char>();
            Stack<string> operationsStack = new Stack<string>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commands = Console.ReadLine()
                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

                if (commands[0] == "1")
                {
                    foreach (var item in commands[1])
                    {
                        charStack.Push(item);

                        if (text == string.Empty)
                        {
                            text = item.ToString();
                        }
                        else
                        {
                            text = text + item.ToString();
                        }
                    }

                    operationsStack.Push(text);
                }
                else if (commands[0] == "2")
                {
                    if (charStack.Count >= int.Parse(commands[1]))
                    {
                        for (int j = 0; j < int.Parse(commands[1]); j++)
                        {
                            charStack.Pop();
                        }

                        text = "";

                        foreach (var item in charStack.Reverse())
                        {
                            text = text + item.ToString();
                        }
                    }
                    else
                    {
                        text = "";
                    }

                    operationsStack.Push(text);
                }
                else if (commands[0] == "3")
                {
                    if (text != "")
                    {
                        var array = text.ToArray<char>();

                        if (array.Length >= int.Parse(commands[1]))
                        {
                            Console.WriteLine(array[int.Parse(commands[1]) - 1]);
                        }
                    }
                }
                else if (commands[0] == "4")
                {
                    operationsStack.Pop();
                    text = operationsStack.Peek();
                }
            }
        }
    }
}
