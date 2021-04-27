using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = elements[0];
            int s = elements[1];
            int x = elements[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            if (queue.Any())
            {
                for (int i = 0; i < s; i++)
                {
                    queue.Dequeue();
                }
            }


            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Contains(x) && queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
