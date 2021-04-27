using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            Queue<string> queue = new Queue<string>();
            int count = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                else if (command == "green")
                {
                    if (queue.Count < n)
                    {
                        n = queue.Count;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        
                        count++;
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                    }
                }
                else
                {
                    queue.Enqueue(command);

                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
