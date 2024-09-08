using System;
using System.Linq;

namespace HowTo
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to print an array without for loop:

            //int n = int.Parse(Console.ReadLine());
            //int[] nums = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    nums[i] = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Готово, въведохме масива.");
            //Console.WriteLine(String.Join(" ", nums));            //Joins the elements of an array into string
            //Console.WriteLine(String.Join("\r\n", nums));         //Каква е разликата между двете???, Печата на един ред!

            // How to print an array with for loop:

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.WriteLine(nums[i]);
            //}

            //Reading arrays
            //Longest example:

            //string values = Console.ReadLine();
            //string[] items = values.Split(' ');               //Splits the string into an array
            //int[] arr = new int[items.Length];
            //
            //for (int i = 0; i < items.Length; i++)
            //{
            //    arr[i] = int.Parse(items[i]);
            //}

            //Shorter example:

            //var inputLine = Console.ReadLine();
            //string[] items = inputLine.Split(' ');
            //int[] arr = items.Select(int.Parse).ToArray();

            //The shortest example:

            //int[] arr = Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .ToArray();

            //Orr

            //int[] arr = Console.ReadLine()
            //    .Split(' ')
            //    .Select(s => int.Parse(s))
            //    .ToArray();

            string[] items = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);  //Removes the empty entries between the input elements
            int[] nums = items.Select(int.Parse).ToArray();

            

        }
    }
}
