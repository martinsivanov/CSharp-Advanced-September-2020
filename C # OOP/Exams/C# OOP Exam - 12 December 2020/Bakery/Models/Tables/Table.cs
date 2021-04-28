using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        public ICollection<IBakedFood> FoodOrders { get; private set; }
        public ICollection<IDrink> DrinkOrders { get; private set; }
        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }


        public bool IsReserved { get; private set; }

        public decimal Price => numberOfPeople * this.PricePerPerson;

        public void Reserve(int numberOfPeople)
        {
            this.numberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
        public void OrderFood(IBakedFood food)
        {
            if (food != null)
            {
                this.FoodOrders.Add(food);

            }
            //Orders the provided food (think of a way to collect all the food which is ordered). //TODO: ??
        }
        public void OrderDrink(IDrink drink)
        {
            if (drink != null)
            {

            this.DrinkOrders.Add(drink);
            }
        }
        public decimal GetBill()
        {
            return this.DrinkOrders.Sum(dr => dr.Price) + this.FoodOrders.Sum(fo => fo.Price) + this.Price; // TODO: MAYBE PORTION ?
        }
        public void Clear()
        {
            this.DrinkOrders.Clear();
            this.FoodOrders.Clear();
            this.IsReserved = false;
            //Removes all of the ordered drinks and food and finally frees the table and sets the count of people to 0.
        }


        public string GetFreeTableInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.capacity}")
                .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
            //"Table: {table number}"
            //"Type: {table type}"
            //"Capacity: {table capacity}"
            //"Price per Person: {price per person for the current table}"

        }

    }
}
