using System;
using System.Linq;

namespace p09ExtractMidleElements
{
    class p09ExtractMidleElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = arr.Length;
            string output = "";
            if (length == 1)
            {
                Console.WriteLine(arr[0]);
            }
            else if (length % 2 == 0)
            {
                length = arr.Length;
                for (int i = 0; i < length; i++)
                {
                    length = arr.Length;
                    if (arr[i] == length / 2)
                    {
                        output += arr[i].ToString() + " ";
                    }
                    if (arr[i] == length / 2 + 1)
                    {
                        output += arr[i].ToString() + " ";
                    }
                }
                length = arr.Length;
            }

            else if (length % 2 != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    if (arr[i] == length / 2)
                    {
                        output += arr[i].ToString() + " ";
                    }
                    if (arr[i] == length / 2 + 1)
                    {
                        output += arr[i].ToString() + " ";
                    }
                    if (arr[i] == length / 2 + 2)
                    {
                        output += arr[i].ToString() + " ";
                    }

                }
            }
            Console.WriteLine(output);
        }
    }
}
