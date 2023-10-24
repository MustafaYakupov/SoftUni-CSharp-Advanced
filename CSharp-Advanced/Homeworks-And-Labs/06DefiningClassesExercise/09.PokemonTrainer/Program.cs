using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] splittedInput = input.Split();

                string trainerName = splittedInput[0];
                string pokemonName = splittedInput[1];
                string element = splittedInput[2];
                int health = int.Parse(splittedInput[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                Trainer trainer = trainers
                    .FirstOrDefault(x => x.Name == trainerName);   // Checks if there is a trainer with the current trainer name, if not returns null

                if (trainer == null)   // If there is no such trainer we add it
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);     // Then we add the pokemon to the trainer

                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == secondInput)) // If the trainer has the pokemon he gets badges
                    {
                        trainer.BadgesCount++;
                    }
                    else                                            // If the trainer doesn't have the pokemon all pokemons' health goes down with 10
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            Pokemon pokemon = trainer.Pokemons[i];

                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }

                secondInput = Console.ReadLine();
            }

            Console.WriteLine(String
                .Join(Environment.NewLine, trainers
                .OrderByDescending(x => x.BadgesCount)));
        }
    }
}
