using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private List<decimal> totalIncome;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = new List<decimal>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;
            if (type == "Bread")
            {
                bakedFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
            }
            this.bakedFoods.Add(bakedFood);
            return String.Format(OutputMessages.FoodAdded, bakedFood.Name, bakedFood.GetType().Name);
            //Creates a food with the correct type.If the food is created successful, returns:
            //"Added {baked food name} ({baked food type}) to the menu"

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            this.drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
            //Creates a drink with the correct type.If the drink is created successful, returns:
            //"Added {drink name} ({drink brand}) to the drink menu"

        }


        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
            //Creates a table with the correct type and returns:
            //"Added table number {table number} in the bakery"

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = null;

            foreach (var tabl in this.tables)
            {
                if (!tabl.IsReserved && tabl.Capacity >= numberOfPeople)
                {
                    table = tabl;
                    break;
                }
            }

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
            //Finds a table which is not reserved, 
            //and its capacity is enough for the number of people provided.If there is no such table returns:
            //"No available table for {numberOfPeople} people"
            //In the other case reserves the table and returns:
            //"Table {table number} has been reserved for {numberOfPeople} people"

        }
        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IBakedFood bakedFood = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (bakedFood == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(bakedFood);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
            //  Finds the table with that number and the food with that name in the menu.
            //If there is no such table returns:
            //"Could not find table {tableNumber}"
            //If there is no such food returns:
            //"No {bakedFoodName} in the menu"
            //In other case orders the food for that table and returns:
            //"Table {tableNumber} ordered {bakedFoodName}"

        }
        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(dr => dr.Name == drinkName && dr.Brand == drinkBrand);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            //Finds the table with that number and finds the drink with that name and brand.
            //If there is no such table, it returns:
            //"Could not find table {tableNumber}"
            //If there isn’t such drink, it returns:
            //"There is no {drinkName} {drinkBrand} available"
            //In other case, it orders the drink for that table and returns:
            //"Table {tableNumber} ordered {drinkName} {drinkBrand}"

        }
        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal tablebill = table.GetBill();
            this.totalIncome.Add(tablebill);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {tablebill:f2}");
            table.Clear();
            return sb.ToString().TrimEnd();
            //Finds the table with the same table number. Gets the bill for that table
            //and clears it.Finally returns:
            //"Table: {tableNumber}"
            //"Bill: {table bill:f2}"

        }
        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in this.tables)
            {
                if (!table.IsReserved)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }
            return sb.ToString().TrimEnd();
            //Finds all not reserved tables and for each table returns the table info.
        }

        public string GetTotalIncome()
        {
            decimal totalIncome = this.totalIncome.Sum();
            return String.Format(OutputMessages.TotalIncome, totalIncome);
        }




    }
}
