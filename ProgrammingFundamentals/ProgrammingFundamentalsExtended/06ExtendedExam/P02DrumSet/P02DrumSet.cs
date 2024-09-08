using System;
using System.Linq;

namespace P02DrumSet
{
    class P02DrumSet
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            var drumset = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var initialDrumset = drumset.ToList();
            string input = Console.ReadLine();

            
            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i <= drumset.Count - 1; i++)
                {

                    if (drumset[i] > hitPower)
                    {
                        drumset[i] -= hitPower;
                    }
                    else
                    {
                        drumset.RemoveAt(i);

                        if (savings > initialDrumset[i] * 3)
                        {
                            savings -= initialDrumset[i] * 3;
                            drumset.Insert(i, initialDrumset[i]);
                        }
                        else
                        {
                            break;
                        }

                        if (drumset.Count <= 0)
                        {
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", drumset));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");

        }   
    }
}
