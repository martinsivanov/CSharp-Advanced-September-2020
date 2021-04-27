using System;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[]> print = (names) => Console.WriteLine(String.Join(Environment.NewLine,names));
            print(names);
            
        }
        //static void Print(string[] names)
        //{
        //    foreach (var name in names)
        //    {
        //        Console.WriteLine(name);
        //    }
        //}
    }
}
