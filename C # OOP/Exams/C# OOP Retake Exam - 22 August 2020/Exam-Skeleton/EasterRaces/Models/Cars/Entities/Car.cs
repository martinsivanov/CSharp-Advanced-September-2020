using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MIN_SYMBOLS = 4;

        private string model;

        protected Car(string model, int horsePower, double cubicCentimeters, 
            int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get 
            { 
                return this.model; 
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MIN_SYMBOLS)
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidModel, nameof(value), MIN_SYMBOLS));
                }
                this.model = value;
            }
        }
        public abstract int HorsePower { get; protected set; }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps) 
        {
            double result = this.CubicCentimeters / this.HorsePower * laps;
            return result;
        }
    }
}
