using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 0.9;
        public Car(double fuelQty, double fuelConsumption, double capacity)
            : base(fuelQty, fuelConsumption, capacity)
        {

        }

        public override double FuelConsumption 
            => base.FuelConsumption + FUEL_CONSUMPTION_INCR;
    }
}
