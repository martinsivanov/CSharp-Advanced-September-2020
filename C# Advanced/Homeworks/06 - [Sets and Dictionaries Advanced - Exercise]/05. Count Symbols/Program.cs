using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (!dict.ContainsKey(current))
                {
                    dict.Add(current, 0);
                }

                dict[current]++;
            }

            foreach (var (c, counter) in dict.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{c}: {counter} time/s");
            }
        }
    }
}
