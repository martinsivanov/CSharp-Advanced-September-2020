using Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    public abstract class Animal : IAnimals
    {
        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }

        public string Name { get; private set; }
        public string FavouriteFood { get; private set; }

    }

}
