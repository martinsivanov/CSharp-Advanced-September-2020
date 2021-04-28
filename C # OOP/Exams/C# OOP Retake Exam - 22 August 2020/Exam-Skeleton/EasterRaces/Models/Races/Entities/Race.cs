using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MIN_SYMBOLS = 5;
        private const int MIN_LABS = 1;

        private string name;
        private int laps;
        private ICollection<IDriver> drivers;
        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }

        public string Name
        {
            //o If the name is null, empty or less than 5 symbols
            //    throw an ArgumentException with message
            //    "Name {name} cannot be less than 5 symbols."
            //    o All names are unique

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
        public int Laps
        {
            //o Throws ArgumentException with message 
            //"Laps cannot be less than 1.", if the laps are less than 1.
            get
            {
                return laps;
            }
            private set
            {
                if (value < MIN_LABS)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LABS));
                }
                laps = value;
            }
        }
        public IReadOnlyCollection<IDriver> Drivers
        => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            //This method adds a Driver to the Race if the Driver is valid.If the Driver is not valid,
            //throw an Exception with the appropriate message.
            //Exceptions are:
            //•	If a Driver is null throw an ArgumentNullException with message "Driver cannot be null."
            //•	If a Driver cannot participate in the Race(the Driver doesn't own a Car) 
            //throw an ArgumentException with message "Driver {driver name} could not participate in race."
            //•	If the Driver already exists in the Race throw an ArgumentNullException with message:
            //"Driver {driver name} is already added in {race name} race."
            
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            else if (driver.CanParticipate == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            else if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            this.drivers.Add(driver);
        }
    }
}
