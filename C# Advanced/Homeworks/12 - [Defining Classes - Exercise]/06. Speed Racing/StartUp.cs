using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Car car = new Car(info[0], double.Parse(info[1]), double.Parse(info[2]), 0);
                allCars.Add(car);
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split().ToArray();

                if (inputArgs[0] == "Drive")
                {
                    string carModel = inputArgs[1];
                    double amountOfKm = double.Parse(inputArgs[2]);

                    allCars.Where(c => c.Model == carModel).ToList().ForEach(c => c.CanMoveDistance(amountOfKm));

                }

                input = Console.ReadLine();
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
