using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int letterCount = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine().Split().ToList();

            Func<List<string>, List<string>> func = Format(letterCount);

            input = func(input);

            Console.WriteLine(String.Join(Environment.NewLine,input));


        }

        static Func<List<string>,List<string>> Format(int letterCount)
        {
            Func<List<string>, List<string>> func = new Func<List<string>, List<string>>((list) =>
             {
                 List<string> result = new List<string>();
                 for (int i = 0; i < list.Count; i++)
                 {
                     if (list[i].Length <= letterCount)
                     {
                         result.Add(list[i]);
                     }
                 }
                 return result;
             });

            return func;
        }
    }
}
