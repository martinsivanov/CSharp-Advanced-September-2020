using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {

        //The cubic centimeters for this type of car are 5000. 
        //Minimum horsepower is 400 and maximum horsepower is 600.
        //If you receive horsepower which is not in the given range 
        //throw ArgumentException with message "Invalid horse power: {horsepower}.".
        private const double CUBIC_CENTIMETERS = 5000;
        private const int MINIMUM_HORSEPOWER = 400;
        private const int MAXIMUM_HORSEPOWER = 600;

        private int horsepower;
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS, MINIMUM_HORSEPOWER, MAXIMUM_HORSEPOWER)
        {
            this.HorsePower = horsepower;
        }

        public override int HorsePower
        {
            get
            {
                return this.horsepower;
            }
            protected set
            {
                if (value < MINIMUM_HORSEPOWER || value > MAXIMUM_HORSEPOWER)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages
                        .InvalidHorsePower, value));
                }
                this.horsepower = value;
            }
        }
    }
}
