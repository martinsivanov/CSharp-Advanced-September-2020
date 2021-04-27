using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        private string model;
        public Cargo cargo;
        public Engine engine;
        public List<Tires> tires;

        public Car(string model, Cargo cargo, Engine engine, List<Tires> tires)
        {
            this.Model = model;
            this.Cargo = cargo;
            
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public List<Tires> Tires { get; set; }
    }
}
