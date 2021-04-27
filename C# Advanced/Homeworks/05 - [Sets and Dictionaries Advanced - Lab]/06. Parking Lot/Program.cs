using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string commands = Console.ReadLine();

            while (commands != "END")
            {
                string[] info = commands.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = info[0];
                string registation = info[1];

                if (command == "IN")
                {
                    if (!parking.Contains(registation))
                    {
                        parking.Add(registation);
                    }
                }

                else
                {
                    if (parking.Contains(registation))
                    {
                        parking.Remove(registation);
                    }
                }

                commands = Console.ReadLine();
            }
            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {

                Console.WriteLine($"{String.Join(Environment.NewLine, parking)}");
            }
        }
    }
}
