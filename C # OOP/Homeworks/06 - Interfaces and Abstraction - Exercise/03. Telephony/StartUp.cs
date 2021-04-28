using System;
using System.Linq;
using Telephony.Models;

namespace Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] callNumbers = Console.ReadLine().Split().ToArray();
            string[] browseSites = Console.ReadLine().Split().ToArray();
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (var numbers in callNumbers)
            {
                if (numbers.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(numbers));
                }
                else
                {
                    Console.WriteLine(smartphone.Call(numbers));
                }
            }
            foreach (var site in browseSites)
            {
                Console.WriteLine(smartphone.Browse(site));
            }
        }
    }
}
