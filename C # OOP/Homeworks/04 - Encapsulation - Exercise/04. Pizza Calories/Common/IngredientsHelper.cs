using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class IngredientsHelper
    {
        private static Dictionary<string, double> doughModifiers = new Dictionary<string, double>
        {

            { "white",1.5 },
            {"wholegrain", 1.0},
            {"crispy", 0.9 },
            {"chewy", 1.1},
            {"homemade", 1.0 }
        };

        public static bool isDoughValid(string doughType)
        {
            string searchedDoughType = doughType.ToLower();
            if (doughModifiers.ContainsKey(searchedDoughType))
            {
                return true;
            }
            return false;
        }

        public static double GetModifierDoughType(string flourTypeOrBakingTechnique)
        {
            string seatchedDoughModifier = flourTypeOrBakingTechnique.ToLower();
            if (doughModifiers.ContainsKey(seatchedDoughModifier))
            {
                return doughModifiers[seatchedDoughModifier];
            }

             throw new Exception(ErrorMassages.InvalidTypeDoughMessage);
        }

        private static Dictionary<string, double> toppingModifiers = new Dictionary<string, double>
        {
            {"meat",1.2 },
            {"veggies", 0.8 },
            {"cheese",1.1 },
            {"sauce",0.9 }
        };

        public static bool isToppingValid(string ToppingType)
        {
            string toppingTypeToLower = ToppingType.ToLower();
            if (toppingModifiers.ContainsKey(toppingTypeToLower))
            {
                return true;
            }
            return false;
        }
        public static double GetModifierToppingType(string toppingType)
        {
            string toppingTypeToLower = toppingType.ToLower();
            if (toppingModifiers.ContainsKey(toppingTypeToLower))
            {
                return toppingModifiers[toppingTypeToLower];
            }
            throw new Exception(ErrorMassages.InvalidTypeToppingMessage);
        }
    }
}
