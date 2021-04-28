using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly FactoryVehicle factoryVehicle;

        public Engine()
        {
            this.factoryVehicle = new FactoryVehicle();
        }
        public void Run()
        {
            Vehicle car = this.ProccesVehicleInfo();
            Vehicle truck = this.ProccesVehicleInfo();
            Vehicle bus = this.ProccesVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split().ToArray();
                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                double argKm = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, argKm);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, argKm);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Drive(bus, argKm);
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, argKm);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, argKm);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, argKm);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        if (vehicleType == "Bus")
                        {
                            this.DriveNoPeople(bus, argKm);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

               
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private void Refuel(Vehicle vehicle, double kilometres)
        {
            vehicle.Refuel(kilometres);
        }
        private void Drive(Vehicle vehicle, double kilometres)
        {
            Console.WriteLine(vehicle.Drive(kilometres));
        }
        private void DriveNoPeople(Vehicle vehicle, double kilometres)
        {
            Console.WriteLine(vehicle.DriveEmpty(kilometres));
        }



        private Vehicle ProccesVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine().Split().ToArray();

            string vehicleType = vehicleArgs[0];
            double fuelQty = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            Vehicle currVehicle = this.factoryVehicle.CreateVehicle(vehicleType, fuelQty, fuelConsumption, tankCapacity);

            return currVehicle;
        }
    }
}
