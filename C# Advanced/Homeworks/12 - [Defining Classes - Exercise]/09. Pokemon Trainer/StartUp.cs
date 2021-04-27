using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                // "{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }
                trainers[trainerName].CollectionsPokemons.Add(pokemon);

                input = Console.ReadLine();
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach ((string trainerName, Trainer trainer) in trainers)
                {
                    if (trainer.CollectionsPokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        int count = trainer.CollectionsPokemons.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Pokemon pokemon = trainer.CollectionsPokemons[i];
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                trainer.CollectionsPokemons.Remove(pokemon);
                                i--;
                                count--;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(t => t.Value.NumberOfBadges).ToDictionary(x => x.Key, p => p.Value);

            foreach ((string trainerName, Trainer trainer) in trainers)
            {
                //"{trainerName} {badges} {numberOfPokemon}"

                Console.WriteLine($"{trainerName} {trainer.NumberOfBadges} {trainer.CollectionsPokemons.Count}");
            }
        }
    }
}
