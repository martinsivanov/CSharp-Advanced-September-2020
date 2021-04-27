using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string colorName = input[0];
                string[] items = input[1].Split(",").ToArray();


                if (!wardrobe.ContainsKey(colorName))
                {
                    wardrobe.Add(colorName, new Dictionary<string, int>());
                }

                foreach (var item in items)
                {
                    if (!wardrobe[colorName].ContainsKey(item))
                    {
                        wardrobe[colorName].Add(item, 0);
                    }
                    wardrobe[colorName][item]++;
                }


            }
            string[] searchItem = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = searchItem[0];
            string itemToFind = searchItem[1];

            foreach (var (colorName, items) in wardrobe)
            {
                Console.WriteLine($"{colorName} clothes:");

                foreach (var item in items)
                {
                    if (item.Key == itemToFind && colorName == colorToFind)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {

                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }

            }
        }
    }
}
