using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int countPeople = 0;
            while (true)
            {
                if (name == "Paid")
                {
                    foreach (var q in queue)
                    {
                        Console.WriteLine(q);
                    }
                    queue.Clear();
                    countPeople = 0;
                }
                else if (name == "End")
                {
                    break;
                }
                else
                {
                    queue.Enqueue(name);
                    countPeople++;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{countPeople} people remaining.");
        }
    }
}
