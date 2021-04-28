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

        public Vehicle CreateVehicle( string vehicleType , double fuelQty , double fuelConsumption , double tankCapacity)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQty, fuelConsumption, tankCapacity);
            }

            if (vehicle.FuelQty > vehicle.Capacity)
            {
                vehicle.FuelQty = 0;
            }

            return vehicle;
        }
    }
}
