using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Food
{
    public class Cake : Dessert
    {
        // • Grams = 250
        //•	Calories = 1000
        //•	CakePrice = 5

        private const double DefaultGrams = 250;
        private const double DefaultCalories = 1000;
        private const decimal DefaultCakePrice = 5;
        public Cake(string name)
            : base(name, DefaultCakePrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
