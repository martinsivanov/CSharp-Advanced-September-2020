using PizzaCalories.Models;
using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
                try
                {
                    string[] pizzaInfo = Console.ReadLine().Split();
                    string pizzaName = pizzaInfo[1];

                    string[] doughInfo = Console.ReadLine().Split();
                    string flourType = doughInfo[1];
                    string bakingTechnique = doughInfo[2];
                    double doughWeight = double.Parse(doughInfo[3]);


                    Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                    Pizza pizza = new Pizza(pizzaName, dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = command.Split();
                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

        }
    }
}
