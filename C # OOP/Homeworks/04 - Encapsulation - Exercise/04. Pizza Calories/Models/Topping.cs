using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private string toppingType;
        private double toppingWeight;

        public Topping(string toppingType, double toppingWeight)
        {
            this.ToppingType = toppingType;
            this.ToppingWeight = toppingWeight;
        }
        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (!IngredientsHelper.isToppingValid(value))
                {
                    throw new Exception(String.Format(ErrorMassages.InvalidTypeToppingMessage, value));
                }
                this.toppingType = value;
            }
        }
        public double ToppingWeight
        {
            get
            {
                return this.toppingWeight;
            }
            private set
            {
                if (value < Constants.MinWeightTopping || value > Constants.MaxWeightTopping)
                {
                    throw new Exception(String.Format(ErrorMassages.InvalidToppingWeightMessage,this.toppingType));
                }
                this.toppingWeight = value;
            }
        }

        public double TotalToppingCalories()
        {
            return Constants.ToppingCaloriesPerGram 
                * IngredientsHelper.GetModifierToppingType(this.toppingType) 
                * this.ToppingWeight;
        }
    }
}
