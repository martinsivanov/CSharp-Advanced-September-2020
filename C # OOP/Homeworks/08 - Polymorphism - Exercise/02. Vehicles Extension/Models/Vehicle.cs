using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.ErrorMessages;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {

        private const double CAR_ADDITIONAL_CONSUMPTION = 0.9;
        private const double TRUCK_ADDITIONAL_CONSUMPTION = 1.6;
        private const double BUS_ADDITIONAL_CONSUMPTION = 1.4;


        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        private const string NOT_ENOUGH_FUEL_MSG = "{0} needs refueling";
        private const string AMOUNT_NOT_POSITIVE_MSG = "Fuel must be a positive number";
        private const string CANNOT_FIT_AMOUNT_TO_TANK_MSG = "Cannot fit {0} fuel in the tank";


        private const double TRUCK_TANK_CAPACITY = 0.95;
        protected Vehicle(double fuelQty, double fuelConsumption, double capacity)
        {
            FuelQty = fuelQty;
            FuelConsumption = fuelConsumption;
            Capacity = capacity;
        }

        public double FuelQty { get; set; }
        public virtual double FuelConsumption { get; set; }

        public double Capacity { get; private set; }




        public virtual string Drive(double amount)
        {
            if (amount * (this.FuelConsumption) <= this.FuelQty)
            {
                this.FuelQty -= amount * (this.FuelConsumption);
                return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);

            }

            else
            {
                return String.Format(NOT_ENOUGH_FUEL_MSG, this.GetType().Name);
            }


        }
        public string DriveEmpty(double amount)
        {
            if (amount * (this.FuelConsumption - BUS_ADDITIONAL_CONSUMPTION) <= this.FuelQty)
            {
                this.FuelQty -= amount * (this.FuelConsumption - BUS_ADDITIONAL_CONSUMPTION);
                return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);

            }

            else
            {
                return String.Format(NOT_ENOUGH_FUEL_MSG, this.GetType().Name);
            }
        }
        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception(AMOUNT_NOT_POSITIVE_MSG);
            }
            if (amount > 0 && amount + this.FuelQty > this.Capacity)
            {
                throw new Exception(String.Format(CANNOT_FIT_AMOUNT_TO_TANK_MSG, amount));
            }

            if (amount > 0 && amount + this.FuelQty <= this.Capacity)
            {
                if (this.GetType().Name == "Truck")
                {
                    this.FuelQty += amount * TRUCK_TANK_CAPACITY;
                }

                else
                {
                    this.FuelQty += amount;
                }
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty:f2}";
        }
    }
}
