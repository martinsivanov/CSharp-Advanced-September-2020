using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        //•	string Model
        //•	double FuelAmount
        //•	double FuelConsumptionPerKilometer
        //•	double Travelled distance
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKillometer;
        private double travelledDistance;


        public Car(string model, double fuelAmount, double fuelConsumptionPerKillometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKillometer = fuelConsumptionPerKillometer;
            TravelledDistance = travelledDistance;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }
        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }

            set
            {
                this.fuelAmount = value;
            }
        }
        public double FuelConsumptionPerKillometer
        {
            get
            {
                return this.fuelConsumptionPerKillometer;
            }
            set
            {
                this.fuelConsumptionPerKillometer = value;
            }
        }
        public double TravelledDistance
        {
            get
            {
                return this.travelledDistance;
            }
            set
            {
                this.travelledDistance = value;
            }
        }

        public void CanMoveDistance(double distance)
        {

            if (this.fuelAmount < this.fuelConsumptionPerKillometer * distance)
            {
               Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.fuelAmount -= this.fuelConsumptionPerKillometer * distance;
                this.TravelledDistance += distance;
            }

        }

    }
}
