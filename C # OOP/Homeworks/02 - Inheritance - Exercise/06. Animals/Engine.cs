using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace P06Animals
{
    public class Engine
    {
        private readonly List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                string[] commandArgs = Console.ReadLine().Split().ToArray();
                Animal animal;
                try
                {
                animal = GetAnimal(type, commandArgs);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                this.animals.Add(animal);
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal GetAnimal(string type, string[] commandArgs)
        {
            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);
            string gender = null;
            Animal animal = null;
            if (commandArgs.Length >= 3)
            {
                gender = commandArgs[2];
            }

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);

            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Kitten(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
