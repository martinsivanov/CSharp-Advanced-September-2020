using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightInterval = int.Parse(Console.ReadLine()); // 10
            int freeWindowInterval = int.Parse(Console.ReadLine()); // 5

            string command;

            Queue<string> queue = new Queue<string>();
            int countPassedCars = 0;
            int indexCrash = 0;
            bool isCrashed = false;
            string crashedCar = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {

                    int tempGreenLightInterval = greenLightInterval;
                    while (queue.Any() && tempGreenLightInterval > 0)
                    {

                        string carName = queue.Peek();
                        if (carName.Length <= tempGreenLightInterval && tempGreenLightInterval > 0)
                        {
                            countPassedCars++;
                            tempGreenLightInterval -= carName.Length;
                            queue.Dequeue();
                        }
                        else
                        {


                            if (carName.Length <= freeWindowInterval + tempGreenLightInterval && tempGreenLightInterval > 0)
                            {
                                if (tempGreenLightInterval <= carName.Length)
                                {
                                    countPassedCars++;
                                    queue.Dequeue();
                                    break;
                                }

                            }
                            else
                            {
                                isCrashed = true;
                                indexCrash = tempGreenLightInterval + freeWindowInterval;
                                crashedCar = carName;
                                break;

                            }

                        }
                    }
                }
                else
                {
                    string carName = command;
                    queue.Enqueue(carName);
                }
                if (isCrashed)
                {
                    break;
                }
            }
            if (isCrashed)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[indexCrash]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countPassedCars} total cars passed the crossroads.");
            }
        }
    }
}
