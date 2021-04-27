using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                //{model} {power} {displacement} {efficiency}
                string model = info[0];
                int power = int.Parse(info[1]);
                if (info.Length == 4)
                {
                    string displacement = info[2];
                    string efficiency = info[3];
                    engines.Add(new Engine(model, power, int.Parse(displacement), efficiency));

                }
                else if (info.Length == 3)
                {

                    int displacement;
                    bool isDisplacement = int.TryParse(info[2], out displacement);
                    if (isDisplacement)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = info[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (info.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }


            }

            int m = int.Parse(Console.ReadLine());
            List<Car> Allcars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] infoCar = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

                // "{model} {engine} {weight} {color}"
                string modelcar = infoCar[0];
                string modelEngine = infoCar[1];

                //Engine engine = new Engine(null,0);
                //foreach (var eng in engines)
                //{
                //    if (engine.Model == modelEngine)
                //    {
                //        engine = eng;
                //    }
                //}
                Engine engine = engines.Where(e => e.Model == modelEngine).FirstOrDefault();

                if (infoCar.Length == 2)
                {
                    Allcars.Add(new Car(modelcar, engine));
                }
                else if (infoCar.Length == 3)
                {
                    int weight;
                    bool isWeight = int.TryParse(infoCar[2], out weight);
                    if (isWeight)
                    {
                        Allcars.Add(new Car(modelcar, engine, weight));
                    }
                    else
                    {
                        string color = infoCar[2];
                        Allcars.Add(new Car(modelcar, engine, color));
                    }
                }
                else if (infoCar.Length == 4)
                {
                    int weight = int.Parse(infoCar[2]);
                    string color = infoCar[3];
                    Allcars.Add(new Car(modelcar, engine, weight, color));
;                }
            }

            foreach (var car in Allcars)
            {
                Console.WriteLine("{0}:", car.Model);
                Console.WriteLine("  {0}:", car.Engine.Model);
                Console.WriteLine("    Power: {0}", car.Engine.Power);
                Console.WriteLine("    Displacement: {0}", car.Engine.Displacement == 0 ? "n/a" : car.Engine.Displacement.ToString());
                Console.WriteLine("    Efficiency: {0}", car.Engine.Efficiency);
                Console.WriteLine("  Weight: {0}", car.Weight == 0 ? "n/a" : car.Weight.ToString());
                Console.WriteLine("  Color: {0}", car.Color);
            }
        }
    }
}
