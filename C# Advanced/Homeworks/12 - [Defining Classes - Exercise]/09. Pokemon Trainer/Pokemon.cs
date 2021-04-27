using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public string name;
        public string element;
        public int health;

        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

    }
}
