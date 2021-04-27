using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "Revision")
                {
                    break;
                }

                string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shopName = inputInfo[0];
                string product = inputInfo[1];
                double price = double.Parse(inputInfo[2]);

                if (!dict.ContainsKey(shopName))
                {
                    dict.Add(shopName, new Dictionary<string, double>());
                }



                if (!dict[shopName].ContainsKey(product))
                {
                    dict[shopName].Add(product, 0);
                }

                dict[shopName][product] = price;

                ;

                input = Console.ReadLine();
            }

            foreach (var (shops, products) in dict.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shops}->");

                foreach (var kvp in products)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
