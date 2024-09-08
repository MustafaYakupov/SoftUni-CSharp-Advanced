using System;
using System.Linq;

namespace p03PokemonDontGo
{
    class p03PokemonDontGo
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int sum = 0;

            while (arr.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removed = 0;

                if (index < 0)
                {
                    removed = arr[0];
                    sum += removed;
                    arr[0] = arr[arr.Count - 1];

                    for (int i = 0; i <= arr.Count - 1; i++)
                    {
                        if (arr[i] <= removed)
                        {
                            arr[i] += removed;
                        }
                        else if (arr[i] > removed)
                        {
                            arr[i] -= removed;
                        }
                    }
                }
                else if (index > arr.Count - 1)
                {
                    removed = arr[arr.Count - 1];
                    sum += removed;
                    arr[arr.Count - 1] = arr[0];

                    for (int i = 0; i <= arr.Count - 1; i++)
                    {
                        if (arr[i] <= removed)
                        {
                            arr[i] += removed;
                        }
                        else if (arr[i] > removed)
                        {
                            arr[i] -= removed;
                        }
                    }
                }
                else
                {
                    removed = arr[index];
                    sum += removed;
                    arr.RemoveAt(index);

                    for (int i = 0; i <= arr.Count - 1; i++)
                    {
                        if (arr[i] <= removed)
                        {
                            arr[i] += removed;
                        }
                        else if (arr[i] > removed)
                        {
                            arr[i] -= removed;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
