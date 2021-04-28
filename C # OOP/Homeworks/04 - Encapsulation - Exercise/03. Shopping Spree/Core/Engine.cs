using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            PeopleInput();
            ProductsInput();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = commandArgs[0];
                string productName = commandArgs[1];
                try
                {
                Person person = this.people.First(p => p.Name == personName);
                Product product = this.products.First(p => p.Name == productName);
                person.BuyProduct(product);
                Console.WriteLine($"{personName} bought {productName}");

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            foreach (Person person in this.people)
            {
                Console.WriteLine($"{person}");
            }
        }

        private void ProductsInput()
        {
            string[] productArgs = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            for (int i = 0; i < productArgs.Length; i++)
            {
                string[] currentProductTokens = productArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string nameProduct = currentProductTokens[0];
                decimal costProduct = decimal.Parse(currentProductTokens[1]);
                Product product = new Product(nameProduct, costProduct);
                this.products.Add(product);
            }
        }

        private void PeopleInput()
        {
            string[] peopleArgs = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] currentPeopleTokens = peopleArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string namePerson = currentPeopleTokens[0];
                decimal moneyPerson = decimal.Parse(currentPeopleTokens[1]);
                Person person = new Person(namePerson, moneyPerson);
                this.people.Add(person);
            }
        }
    }
}
