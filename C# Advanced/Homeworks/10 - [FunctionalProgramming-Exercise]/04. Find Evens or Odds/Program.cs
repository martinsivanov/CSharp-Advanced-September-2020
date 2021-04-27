using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] limits = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Predicate<int> predicate = GetPredicate(command);

            List<int> result = new List<int>();

            for (int i = limits[0]; i <= limits[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }

        static Predicate<int> GetPredicate(string command)
        {

            if (command == "odd")
            {
                return new Predicate<int>((n) => n % 2 != 0);
            }
            else
            {
                return new Predicate<int>((n) => n % 2 == 0);
            }
        }
    }
}

