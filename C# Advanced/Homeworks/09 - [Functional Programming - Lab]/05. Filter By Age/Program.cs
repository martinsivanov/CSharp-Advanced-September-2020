using System;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        class People
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            People[] people = new People[n];

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(", ").ToArray();
                string name = info[0];
                int age = int.Parse(info[1]);
                people[i] = new People();

                people[i].Name = name;
                people[i].Age = age;


            }
            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<People, bool> checkCondition = CheckCondition(condition, ageFilter);
            Action<People> printer = Print(format);

            foreach (var person in people)
            {
                if (checkCondition(person))
                {
                    printer(person);
                }
            }
        }

        private static Action<People> Print(string format)
        {
            if (format == "name")
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            else if (format == "age")
            {

                return p => Console.WriteLine($"{p.Age}");
            }
            else if (format == "name age")
            {

                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            else
            {
                return null;
            }
        }

        static Func<People, bool> CheckCondition(string condition, int ageFilter)
        {
            if (condition == "older")
            {
                return p => p.Age >= ageFilter;
            }
            else if (condition == "younger")
            {
                return p => p.Age < ageFilter;
            }
            else
            {
                return null;
            }
        }
    }
}
