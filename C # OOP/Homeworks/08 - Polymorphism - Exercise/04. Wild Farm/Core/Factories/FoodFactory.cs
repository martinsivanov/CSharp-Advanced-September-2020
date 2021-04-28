using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Core.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string name, int qty)
        {
            Food food = null;

            if (name == "Vegetable")
            {
                food = new Vegetable(qty);
            }
            else if (name == "Fruit")
            {
                food = new Fruit(qty);
            }
            else if (name == "Meat")
            {
                food = new Meat(qty);
            }
            else if (name == "Seeds")
            {
                food = new Meat(qty);
            }

            return food;
        }
    }
}
