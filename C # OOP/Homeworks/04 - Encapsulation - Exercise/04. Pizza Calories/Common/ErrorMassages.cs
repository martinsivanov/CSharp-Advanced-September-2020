using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class ErrorMassages
    {

        public static string InvalidTypeDoughMessage = "Invalid type of dough.";
        public static string IvalidDoughWeightMessage = "Dough weight should be in the range [1..200].";
        public static string InvalidTypeToppingMessage = "Cannot place {0} on top of your pizza.";
        public static string InvalidToppingWeightMessage = "{0} weight should be in the range [1..50].";
        public static string InvalidPizzaNameMessage = "Pizza name should be between 1 and 15 symbols.";
        public static string InvalidToppingsCountMessage = "Number of toppings should be in range [0..10].";
    }
}
