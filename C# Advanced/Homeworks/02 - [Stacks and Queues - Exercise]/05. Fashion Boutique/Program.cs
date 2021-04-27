using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);
            int sum = 0;
            int count = 0;
            while (stack.Any())
            {
                // 5 4 8 6 3 8 7 7 9
                // 16


                int current = stack.Peek();
                if (current + sum > capacity)
                {
                    count++;
                    sum = 0;
                }
                else
                {
                    sum += current;
                    if (stack.Count == 1)
                    {
                        count++;
                    }
                    stack.Pop();
                }


            }
            Console.WriteLine(count);
        }
    }
}
