using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int current = numbers[i];
                if (current % 2 == 0)
                {
                    queue.Enqueue(current);
                }

            }
            int count = 0;
            foreach (var q in queue)
            {
                count++;
                if (count == queue.Count)
                {

                    Console.Write($"{q}");
                }
                else
                {
                    Console.Write($"{q}, ");
                }
                
            }
        }
    }
}
