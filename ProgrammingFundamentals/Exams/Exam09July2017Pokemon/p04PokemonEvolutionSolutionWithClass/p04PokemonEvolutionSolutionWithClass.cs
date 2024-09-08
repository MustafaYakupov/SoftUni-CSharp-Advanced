using System;
using System.Collections.Generic;
using System.Linq;

namespace p04PokemonEvolutionSolutionWithClass
{
    class p04PokemonEvolutionSolutionWithClass
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Evolution>> pokemons = new Dictionary<string, List<Evolution>>();
            string[] input = Console.ReadLine().Split(new char[] { '-', '>', ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = "";

            while (input[0] != "wubbalubbadubdub")
            {
                if (input.Length > 1)
                {
                    Evolution evolution = new Evolution();
                    evolution.Type = input[1];
                    evolution.Power = int.Parse(input[2]);
                    name = input[0];

                    if (pokemons.ContainsKey(name) == false)
                    {
                        List<Evolution> currentList = new List<Evolution>() { evolution };
                        pokemons.Add(name, currentList);
                    }
                    else
                    {
                        pokemons[name].Add(evolution);
                    }
                }
                else
                {
                    name = input[0];

                    if (pokemons.ContainsKey(name))
                    {
                        Console.WriteLine($"# {name}");

                        foreach (var ev in pokemons[name])
                        {
                            Console.WriteLine($"{ev.Type} <-> {ev.Power}");
                        }
                    }
                }
                input = Console.ReadLine().Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            foreach (var pair in pokemons)
            {
                Console.WriteLine($"# {pair.Key}");
                foreach (var evoluiton in pair.Value.OrderByDescending(x => x.Power))
                {
                    Console.WriteLine($"{evoluiton.Type} <-> {evoluiton.Power}");

                }
            }
        }
    }

    class Evolution
    {
        public string Type { get; set; }

        public int Power { get; set; }
    }
}
