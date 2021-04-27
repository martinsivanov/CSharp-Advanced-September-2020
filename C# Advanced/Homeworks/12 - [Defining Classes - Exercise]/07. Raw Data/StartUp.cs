using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} " 
                //"{tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                double tire1Pressure = double.Parse(info[5]);
                int tire1Age = int.Parse(info[6]);

                double tire2Pressure = double.Parse(info[7]);
                int tire2Age = int.Parse(info[8]);

                double tire3Pressure = double.Parse(info[9]);
                int tire3Age = int.Parse(info[10]);

                double tire4Pressure = double.Parse(info[11]);
                int tire4Age = int.Parse(info[12]);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tires> tires = new List<Tires>();
                for (int j = 5; j < info.Length; j += 2)
                {

                    Tires tiresInfo = new Tires(double.Parse(info[j]), int.Parse(info[j + 1]));
                    tires.Add(tiresInfo);
                }
                Car car = new Car(model, cargo, engine, tires);
                allCars.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                allCars.Where(c => c.Cargo.CargoType == command).Where(t => t.Tires.Any(t => t.TirePressure < 1)).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            if (command == "flamable")
            {
                allCars.Where(c => c.Cargo.CargoType == command).Where(e => e.Engine.EnginePower > 250).ToList().ForEach(x => Console.WriteLine(x.Model));
              
            }
        }
    }
}
