using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string trainerName;
        public int numberOfBadges;
        public List<Pokemon> collectionsPokemons;

        public Trainer(string trainerName)
        {
            this.TrainerName = trainerName;
            this.NumberOfBadges = 0;
            this.CollectionsPokemons = new List<Pokemon>();
        }


        public string TrainerName { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionsPokemons { get; set; }

    }
}
