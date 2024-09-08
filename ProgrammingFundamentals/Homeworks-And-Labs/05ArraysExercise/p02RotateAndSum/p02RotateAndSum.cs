using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02RotateAndSum
{
    class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] result = new int[array.Length];

            for (int i = 0; i < rotations; i++)
            {
                int lastDigit = array[array.Length - 1];
                for (int k = array.Length - 1; k > 0; k--)
                {
                    array[k] = array[k - 1];
                    result[k] += array[k];
                }
                array[0] = lastDigit;
                result[0] += array[0];
            }

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}