using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {

        //The cubic centimeters for this type of car are 3000.
        //Minimum horsepower is 250 and maximum horsepower is 450.
        //If you receive horsepower which is not in the given 
        //range throw ArgumentException with message "Invalid horse power: {horsepower}.".
        private const double CUBIC_CENTIMETERS = 3000;
        private const int MINIMUM_HORSEPOWER = 250;
        private const int MAXIMUM_HORSEPOWER = 450;


        private int horsePower;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS, MINIMUM_HORSEPOWER, MAXIMUM_HORSEPOWER)
        {

        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MINIMUM_HORSEPOWER || value > MAXIMUM_HORSEPOWER)
                {
                    throw new ArgumentException(String.Format
                        (ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
