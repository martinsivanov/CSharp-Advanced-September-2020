using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();
            List<Robot> robots = new List<Robot>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split().ToArray();

                if (commandArgs[0] == "Citizen")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string date = commandArgs[4];
                    Citizen citizen = new Citizen(name, age, id, date);
                    birthdates.Add(citizen);
                }
                else if (commandArgs[0] == "Robot")
                {
                    Robot robot = new Robot(commandArgs[1], commandArgs[2]);
                    robots.Add(robot);
                }
                else if (commandArgs[0] == "Pet")
                {
                    Pet pet = new Pet(commandArgs[1], commandArgs[2]);
                    birthdates.Add(pet);
                }

            }
            string yearToFind = Console.ReadLine();
            foreach (var birdate in birthdates)
            {
                if (birdate.BirthDate.EndsWith(yearToFind))
                {
                    Console.WriteLine(birdate.BirthDate);
                }
            }
        }
    }
}
