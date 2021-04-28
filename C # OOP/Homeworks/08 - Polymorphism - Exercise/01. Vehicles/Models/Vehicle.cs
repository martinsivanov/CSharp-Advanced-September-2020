using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.ErrorMessages;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        protected Vehicle(double fuelQty, double fuelConsumption)
        {
            FuelQty = fuelQty;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQty { get; private set; }
        public virtual double FuelConsumption { get; private set; }

        public virtual string Drive(double amount)
        {
            double fuelNeeded = amount * this.FuelConsumption;
            if (fuelNeeded > this.FuelQty)
            {
                throw new Exception(String.Format
                    (ErrorMessageExeptions.NOT_ENOUGH_FUEL_MSG, this.GetType().Name));
            }

            this.FuelQty -= fuelNeeded;
            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);
        }

        public virtual void Refuel(double amount)
        {
            this.FuelQty += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty:f2}";
        }
    }
}
