using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class FactoryVehicle
    {
        public FactoryVehicle()
        {

        }

        public Vehicle CreateVehicle( string vehicleType , double fuelQty , double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption);
            }

            return vehicle;
        }
    }
}
