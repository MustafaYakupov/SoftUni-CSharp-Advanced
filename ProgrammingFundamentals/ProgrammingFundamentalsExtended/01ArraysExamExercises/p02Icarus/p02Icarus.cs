using System;
using System.Linq;

namespace Icarus02
{
    class Icarus02
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int position = int.Parse(Console.ReadLine());
           
            int damage = 1;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens[0] == "Supernova")
                {
                    break;
                }

                string direction = tokens[0];
                int steps = int.Parse(tokens[1]);
               
                if (direction == "left")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (position == 0)
                        {
                            position = arr.Count - 1;
                            damage++;
                        }
                        else
                        {
                            position--;
                        }
                        arr[position] -= damage;
                    }
                }
                else if (direction == "right")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (position == arr.Count - 1)
                        {
                            position = 0;
                            damage++;
                        }
                        else
                        {
                            position++;
                        }
                        arr[position] -= damage;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
