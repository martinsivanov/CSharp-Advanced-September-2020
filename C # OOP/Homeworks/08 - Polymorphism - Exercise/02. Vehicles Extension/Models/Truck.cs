using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {

        private const double FUEL_CONSUMPTION_INCR = 1.6;
        public Truck(double fuelQty, double fuelConsumption, double capacity)
            : base(fuelQty, fuelConsumption, capacity)
        {

        }
        public override double FuelConsumption =>
            base.FuelConsumption + FUEL_CONSUMPTION_INCR;

        public override void Refuel(double amount)
        {

            base.Refuel(amount/* * FUEL_MAX_CAPACITY*/);
        }

    }
}
