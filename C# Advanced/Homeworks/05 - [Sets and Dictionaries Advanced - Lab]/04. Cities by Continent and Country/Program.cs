using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = input[0];
                string country = input[1];
                string town = input[2];

                if (!map.ContainsKey(continent))
                {
                    map.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }

                map[continent][country].Add(town);


            }

            foreach (var (continent, countrys) in map)
            {
                Console.WriteLine($"{continent}: ");
                foreach (var kvp in countrys)
                {
                    Console.WriteLine($"{kvp.Key} -> {String.Join(", ", kvp.Value)}");
                }
            }
        }
    }
}
