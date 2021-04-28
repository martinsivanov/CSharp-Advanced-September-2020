using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MIN_SYMBOLS = 5;
        private string name;

        public Driver(string name)
        {
            Name = name;
        }

        //•	Name - string
        //o   If the name is null, empty or less than 5 symbols 
        // throw an ArgumentException with message "Name {name} cannot be less than 5 symbols."
        //o All names are unique

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < MIN_SYMBOLS)
                {
                    throw new ArgumentException(String.Format
                        (ExceptionMessages.InvalidName, nameof(value), MIN_SYMBOLS));
                }
                name = value;
            }
        }
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            //This method adds a Car to the Driver. If the car is null,
            //throw ArgumentNullException with message "Car cannot be null.".
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            this.CanParticipate = true;

        }
        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
