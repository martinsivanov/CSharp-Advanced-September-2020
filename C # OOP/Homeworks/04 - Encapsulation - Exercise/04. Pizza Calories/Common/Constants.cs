using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class Constants
    {
        // Dough
        public const double DoughCaloriesPerGram = 2;
        public const double MinWeightDough = 1;
        public const double MaxWeightDough = 200;


        //Topping
        public const double ToppingCaloriesPerGram = 2;
        public const double MinWeightTopping = 1;
        public const double MaxWeightTopping = 50;

        //Pizza
        public const double MaxNameLenght = 15;
        public const double MaxToppingsCount = 10;
    }
}
