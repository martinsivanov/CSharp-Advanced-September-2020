namespace TheRace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceEntry
    {
        private const string ExistingDriver = "Driver {0} is already added.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string DriverAdded = "Driver {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";

        private Dictionary<string, UnitDriver> driver;

        public RaceEntry()
        {
            //TODO: TEST -  DONE
            this.driver = new Dictionary<string, UnitDriver>();
        }

        //TODO: TEST - DONE
        public int Counter
            => this.driver.Count;

        public string AddDriver(UnitDriver driver)
        {
            if (driver == null)
            {
                //TODO: TEST - DONE
                throw new InvalidOperationException(DriverInvalid);
            }

            if (this.driver.ContainsKey(driver.Name))
            {
                //TODO: TEST - Done
                throw new InvalidOperationException(string.Format(ExistingDriver, driver.Name));
            }

            //TODO: TEST -
            this.driver.Add(driver.Name, driver);

            string result = string.Format(DriverAdded, driver.Name);

            return result;
        }

        public double CalculateAverageHorsePower()
        {
            if (this.driver.Count < MinParticipants)
            {
                //TODO: TEST - DONE
                throw new InvalidOperationException(string.Format(RaceInvalid, MinParticipants));
            }

            //TODO: TEST - DONE
            double averageHorsePower = this.driver
                .Values
                .Select(x => x.Car.HorsePower)
                .Average();

            return averageHorsePower;
        }
    }
}