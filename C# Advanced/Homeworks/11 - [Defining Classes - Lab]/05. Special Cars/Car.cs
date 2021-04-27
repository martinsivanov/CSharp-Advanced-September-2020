﻿using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
            : this("VW", "Golf", 2025, 200, 10)
        {

        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(int distance)
        {
            double neededFuel = this.FuelConsumption * distance / 100;

            if (this.FuelQuantity - neededFuel <= 0)
            {
                throw new InvalidOperationException("Not enough fuel !");
            }

            this.FuelQuantity -= neededFuel;
        }

        public string TotalCarInformation()
        {
            return $"Make: {this.Make}{Environment.NewLine}" +
            $"Model: {this.Model}{Environment.NewLine}" +
            $"Year: {this.Year}{Environment.NewLine}" +
            $"HorsePowers: {this.Engine.HorsePower}{Environment.NewLine}" +
            $"FuelQuantity: {this.FuelQuantity}";
        }
    }
}
