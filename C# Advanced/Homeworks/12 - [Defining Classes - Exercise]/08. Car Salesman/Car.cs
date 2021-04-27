using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        //• Model
        //•	Engine
        //•	Weight 
        //•	Color
        private string model;
        private Engine engine;
        private int weight;
        private string color;

       
        public Car(string model, Engine engine)
        {
            this.Weight = 0;
            this.Color = "n/a";
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            :this(model,engine)
        {
            
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            :this(model,engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model,engine)
        {
            Color = color;
            Weight = weight;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }


        //public override string ToString()
        //{
        //         //          { CarModel}:
        //         //{ EngineModel}:
        //         //  Power: { EnginePower}
        //         //      Displacement: { EngineDisplacement}
        //         //      Efficiency: { EngineEfficiency}
        //        //      Weight: { CarWeight}
        //        //      Color: { CarColor}

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"{this.Model}:");
        //    sb.AppendLine($"  {this.Engine.Model}:");
        //    sb.AppendLine($"    Power: {this.Engine.Power}");
        //    sb.AppendLine($"    Displacement: {this.Engine.Displacement}");


        //    return 
        //}
    }
}
