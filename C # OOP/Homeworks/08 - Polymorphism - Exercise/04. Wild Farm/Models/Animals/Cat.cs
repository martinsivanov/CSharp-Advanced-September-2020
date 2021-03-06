using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override ICollection<Type> PrefferedFoods => new List<Type>()
        {
            typeof(Meat), typeof(Vegetable)
        };

        public override string PoduceSound()
        {
            return "Meow";
        }
    }
}
