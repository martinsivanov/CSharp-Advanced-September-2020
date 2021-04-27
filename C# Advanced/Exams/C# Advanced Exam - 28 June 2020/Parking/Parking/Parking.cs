using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        //•	Type: string
        //•	Capacity: int
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count();
        public Parking()
        {
            this.data = new List<Car>();
        }

        public Parking(string type, int capacity)
            :this()
        {
            Type = type;
            Capacity = capacity;
        }

        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = data.Where(c => c.Manufacturer == manufacturer).FirstOrDefault(c => c.Model == model);
            if (car != null)
            {
                data.Remove(car);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            Car car = data.OrderByDescending(c => c.Year).FirstOrDefault();
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.Where(c => c.Manufacturer == manufacturer).FirstOrDefault(c => c.Model == model);
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                 sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
