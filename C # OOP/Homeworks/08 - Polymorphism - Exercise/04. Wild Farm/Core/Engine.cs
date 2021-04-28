using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Core.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {
            animals = new HashSet<Animal>();

            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = commandArgs[0];
                string name = commandArgs[1];
                double weight = double.Parse(commandArgs[2]);

                string[] args = commandArgs.Skip(3).ToArray();
                Animal animal = null;

                try
                {
                    animal = animalFactory.CreateAnimal(type, name, weight, args);

                    if (animal != null)
                    {
                        this.animals.Add(animal);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                string[] foodInfo = Console.ReadLine().Split().ToArray();

                string foodName = foodInfo[0];
                int qty = int.Parse(foodInfo[1]);

                Food food = null;

                food = this.foodFactory.CreateFood(foodName, qty);


                try
                {
                    Console.WriteLine(animal.PoduceSound());
                    animal.Feed(food);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            foreach (Animal animal1 in animals)
            {
                Console.WriteLine(animal1);
            }
        }
    }
}
