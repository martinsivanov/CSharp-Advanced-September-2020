using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Action<string> action = text => text.Split().ToList().ForEach(x => Console.WriteLine($"Sir {x}"));
            action(input);
        }
    }
}
