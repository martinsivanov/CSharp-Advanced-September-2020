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
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split().ToArray();
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);

                if (commandArgs.Length == 4)
                {
                    buyers.Add(new Citizen(name, age, commandArgs[2], commandArgs[3]));

                }
                else if (commandArgs.Length == 3)
                {
                    buyers.Add(new Rebel(name, age, commandArgs[2]));
                }
            }
            string command;
            int totalFoods = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;
                int Foods = 0;
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == name)
                    {
                       Foods = buyer.BuyFood();
                    }
                }
                
                totalFoods += Foods;
                
            }
            Console.WriteLine(totalFoods);
        }
    }
}
