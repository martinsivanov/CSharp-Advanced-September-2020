using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            if (stack.Any())
            {
                for (int i = 0; i < s; i++)
                {
                    stack.Pop();
                }
            }


            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (!stack.Contains(x) && stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
