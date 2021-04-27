using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> list = new Queue<string>(songs);

            while (list.Any())
            {
                string[] commands = Console.ReadLine().Split().ToArray();


                if (commands.Contains("Play"))
                {
                    list.Dequeue();
                }
                else if (commands.Contains("Add"))
                {
                    string name = string.Empty;
                    for (int i = 1; i < commands.Length; i++)
                    {
                        if (i == commands.Length - 1)
                        {
                            name += commands[i];
                        }
                        else
                        {

                            name += commands[i] + " ";
                        }
                    }
                    if (!list.Contains(name))
                    {
                        list.Enqueue(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already contained!");
                    }
                }
                else if (commands.Contains("Show"))
                {
                    Console.WriteLine(String.Join(", ", list));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
