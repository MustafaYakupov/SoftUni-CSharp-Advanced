using System;
using System.Collections.Generic;
using System.Linq;

namespace p05KaminoFactory
{
    class p05KaminoFactory
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] final = new int[length];
            int index = 0;
            int finaIndex = 0;
            int[] nums = new int[length];

            while (input == "Clone them!" == false)
            {
                index++;
                nums = input.Split(new char[] { '!', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] parameters = GetInfo(nums);

                if (IsBetter(parameters,final))
                {
                    final = nums;
                    finaIndex = index;
                }
                if (finaIndex == 0)
                {
                    final = nums;
                    finaIndex = index;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {finaIndex} with sum: {final.Sum()}.");
            Console.WriteLine(string.Join(" ", final));
        }

        private static bool IsBetter(int[] parameters, int[] final)
        {
            int[] finalParameters = GetInfo(final);

            if (parameters[0] > finalParameters[0])
            {
                return true;
            }
            else if (parameters[0] == finalParameters[0])
            {
                if (parameters[1] < finalParameters[1])
                {
                    return true;
                }
                else if (parameters[1] == finalParameters[1])
                {
                    if (parameters[2] > finalParameters[2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static int[] GetInfo(int[] nums)
        {
            int sequence = 0;
            int position = 0;
            int sum = nums.Sum();
            int counter = 0;
            int counterMax = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    counter++;

                    if (counter > counterMax)
                    {
                        counterMax = counter;
                        position = i - counter + 1;
                    }
                }
                else
                {
                    counter = 0;
                }

            }
            sequence = counterMax;
            return new int[] { sequence, position, sum };
        }
    }
}
