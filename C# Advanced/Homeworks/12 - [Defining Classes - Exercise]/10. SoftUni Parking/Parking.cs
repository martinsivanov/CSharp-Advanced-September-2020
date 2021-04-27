using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        private int count;
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }


        public int Capacity { get; set; }

        public int Count 
        {
            get
            {
              return  this.count = cars.Count;
            }
            set
            {
                this.count = value;
            }
        }
        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
               return "Car with that registration number, already exists!";
            }
            else if (cars.Count >= this.Capacity)
            {
              return $"Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var reg in registrationNumbers)
            {
                var car = cars.FirstOrDefault(c => c.RegistrationNumber == reg);
                cars.Remove(car);
            }
            
        }
    }
}
