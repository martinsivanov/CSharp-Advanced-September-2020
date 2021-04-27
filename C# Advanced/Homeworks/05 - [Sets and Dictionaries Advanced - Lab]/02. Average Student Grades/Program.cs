using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = info[0];
                decimal grade = decimal.Parse(info[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<decimal>());
                }
                dict[name].Add(grade);

            }



            decimal avg = 0;
            foreach (var student in dict)
            {
                avg = student.Value.Average();


                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }


                Console.Write($"(avg: {avg:f2})");

                Console.WriteLine();
            }
        }
    }
}
