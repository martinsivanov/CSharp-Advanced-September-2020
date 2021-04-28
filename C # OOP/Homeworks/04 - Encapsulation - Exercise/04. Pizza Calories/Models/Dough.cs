using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weightGrams;

        public Dough(string flourType , string bakingTechnique , double weightGrams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.WeightGrams = weightGrams;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
           private set
            {
                if (!IngredientsHelper.isDoughValid(value))
                {
                    throw new Exception(ErrorMassages.InvalidTypeDoughMessage);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
           private set
            {
                if (!IngredientsHelper.isDoughValid(value))
                {
                    throw new Exception(ErrorMassages.InvalidTypeDoughMessage);
                }
                this.bakingTechnique = value;
            }
        }

        public double WeightGrams
        {
            get
            {
                return this.weightGrams;
            }
           private set
            {
                if (value < Constants.MinWeightDough || value > Constants.MaxWeightDough)
                {
                    throw new Exception(ErrorMassages.IvalidDoughWeightMessage);
                }
                this.weightGrams = value;
            }
        }

        public double TotalCalories()
        {
            //(2 * 100) * 1.5 * 1.1 = 330.00

            double total = Constants.DoughCaloriesPerGram * this.WeightGrams
                * IngredientsHelper.GetModifierDoughType(this.FlourType)
                * IngredientsHelper.GetModifierDoughType(this.BakingTechnique);
            return total;
        }
    }
}
