using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();


            int[] lenghts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < lenghts[0]; i++)
            {
                int input = int.Parse(Console.ReadLine());

                first.Add(input);
            }
            for (int i = 0; i < lenghts[1]; i++)
            {

                int input = int.Parse(Console.ReadLine());
                second.Add(input);
            }


            Console.WriteLine(String.Join(" ", first.Intersect(second)));
        }
    }
}
