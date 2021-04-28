using EasterRaces.Core.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_RACE_PARTICIPANTS = 3;

        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver searchDriver = this.drivers.GetByName(driverName);
            if (searchDriver == null)
            {
                IDriver driver = new Driver(driverName);

                this.drivers.Add(driver);
                return String.Format(OutputMessages.DriverCreated, driverName);
            }
            else
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.DriversExists, driverName));
            }
        }
        public string CreateCar(string type, string model, int horsePower)
        {

            if (this.cars.GetByName(type) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, type));
            }
            else
            {
                ICar car = null;
                if (type == "Muscle")
                {
                    car = new MuscleCar(model, horsePower);
                }
                else if (type == "Sports")
                {
                    car = new SportsCar(model, horsePower);
                }
                string result = string.Empty;
                if (car != null)
                {
                    this.cars.Add(car);
                    result = String.Format(OutputMessages.CarCreated, car.GetType().Name, car.Model);

                }
                return result;
            }
            //Create a Car with the provided model and horsepower 
            //and add it to the repository.There are two types of Car: "Muscle" and "Sports".
            //If the Car already exists in the appropriate repository 
            //throw an ArgumentException with following message:
            //"Car {model} is already created."
            //If the Car is successfully created, the method should return the following message:
            //"{"MuscleCar"/ "SportsCar"} {model} is created."

        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.cars.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            string result = String.Format(OutputMessages.CarAdded, driverName, carModel);
            return result;


            //Gives the Car with given name to the Driver with given name(if exists).
            //If the Driver does not exist in the DriverRepository,
            // throw InvalidOperationException with message 
            //•	"Driver {name} could not be found."
            //If the Car does not exist in the CarRepository, 
            //throw InvalidOperationException with message 
            //•	"Car {name} could not be found."
            //If everything is successful you should add the Car to
            //the Driver and return the following message:
            //•	"Driver {driver name} received car {car name}."

        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IRace race = this.races.GetByName(raceName);
            IDriver driver = this.drivers.GetByName(driverName);
            string result;
            //if (driver.CanParticipate)
            //{

            race.AddDriver(driver);
            result = String.Format(OutputMessages.DriverAdded, driverName, raceName);
            return result;
            // }
            //else
            //{
            //    result = String.Format(ExceptionMessages.DriverNotParticipate,driverName);
            //}
            //return result;
            //Adds a Driver to the Race.
            //If the Race does not exist in the RaceRepository,
            //throw an InvalidOperationException with message:
            //•	"Race {name} could not be found."
            //If the Driver does not exist in the DriverRepository,
            //throw an InvalidOperationException with message:
            //•	"Driver {name} could not be found."
            //If everything is successful, you should add the Driver to the Race and
            //return the following message:
            //•	"Driver {driver name} added in {race name} race."

        }

        public string CreateRace(string name, int laps)
        {

            IRace searchRace = this.races.GetByName(name);
            if (searchRace != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            else
            {
                IRace race = new Race(name, laps);

                this.races.Add(race);
                string result = String.Format(OutputMessages.RaceCreated, name);
                return result;
            }

            //Creates a Race with the given name and laps and adds it to the RaceRepository.
            //If the Race with the given name already exists, 
            //throw an InvalidOperationException with message:
            //•	"Race {name} is already create."
            //If everything is successful you should return the following message:
            //•	"Race {name} is created."

        }
        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }


            if (race.Drivers.Count < MIN_RACE_PARTICIPANTS)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MIN_RACE_PARTICIPANTS));
            }

            //This method is the big deal.If everything is valid, you should arrange all Drivers 
            //and then return the three fastest Drivers.To do this you should sort all Drivers in descending
            //order by the result of CalculateRacePoints method in the Car object.At the end, 
            //if everything is valid remove this Race from the race repository.
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (var driver in race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)))
            {
                counter ++;
                if (counter == 1)
                {
                    sb.AppendLine($"Driver {driver.Name} wins {race.Name} race.");
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Driver {driver.Name} is second in {race.Name} race.");
                }
                else if (counter == 3)
                {
                    sb.AppendLine($"Driver {driver.Name} is third in {race.Name} race.");
                }
                else
                {
                    break;
                }
            }
            //"Driver {first driver name} wins {race name} race."
            //"Driver {second driver name} is second in {race name} race."
            //"Driver {third driver name} is third in {race name} race."
            this.races.Remove(race);

            return sb.ToString().TrimEnd();
        }



    }
}
