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
            List<IIdentifiable> all = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split().ToArray();

                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    IIdentifiable person = new Citizen(name, age, id);
                    all.Add(person);
                }
                else if (commandArgs.Length == 2)
                {
                    string model = commandArgs[0];
                    string id = commandArgs[1];
                    IIdentifiable robot = new Robot(model, id);
                    all.Add(robot);
                }
            }

            string lastDigitsFake = Console.ReadLine();

            foreach (var PersonOrRobot in all)
            {
                if (PersonOrRobot.Id.EndsWith(lastDigitsFake))
                {
                    Console.WriteLine(PersonOrRobot.Id);
                }
            }
        }
    }
}
