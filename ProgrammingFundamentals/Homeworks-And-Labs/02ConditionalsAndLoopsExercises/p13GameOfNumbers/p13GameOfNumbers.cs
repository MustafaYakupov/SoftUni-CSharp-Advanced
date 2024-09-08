using System;

namespace p13GameOfNumbers
{
    class p13GameOfNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magical = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = m; i >= n; i--)
            {
                for (int k = m; k >= n; k--)
                {
                    count++;
                    if (i + k == magical)
                    {
                        
                        Console.WriteLine($"Number found! {i } + { k} = {magical}");
                        return;
                    }
                   
                    
                       
                    
                }
            }
            Console.WriteLine($"{count} combinations - neither equals {magical}");

        }
    }
}
