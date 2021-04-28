using Microsoft.VisualBasic;
using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Constants = PizzaCalories.Common.Constants;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.toppings = new List<Topping>();
            this.Name = name;
            this.dough = dough;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > Constants.MaxNameLenght)
                {
                    throw new Exception(ErrorMassages.InvalidPizzaNameMessage);
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= Constants.MaxToppingsCount)
            {
                throw new Exception(ErrorMassages.InvalidToppingsCountMessage);
            }
            toppings.Add(topping);
        }

        public double TotalPizzaCalories()
        {
            double doughCalories = this.dough.TotalCalories();
            double sumToppings = this.toppings.Sum(t => t.TotalToppingCalories());

            return doughCalories + sumToppings;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalPizzaCalories():f2} Calories.";
        }
    }
}
