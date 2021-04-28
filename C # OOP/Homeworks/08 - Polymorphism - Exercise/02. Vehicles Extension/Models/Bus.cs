using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.ErrorMessages;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        private const string NOT_ENOUGH_FUEL_MSG = "{0} needs refueling";

        private const double FUEL_INCR_CONSUMPTION = 1.4;

        public Bus(double fuelQty, double fuelConsumption, double capacity)
            : base(fuelQty, fuelConsumption, capacity)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + FUEL_INCR_CONSUMPTION;


        public override string Drive(double amount)
        {
            // Air conditioner turned On
            return base.Drive(amount);
        }


        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }


    }
}
