using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {

                string[] commands = Console.ReadLine().Split().ToArray();


                if (commands[0] == "1")
                {
                    int x = int.Parse(commands[1]);
                    stack.Push(x);

                }
                else if (commands[0] == "2" && stack.Any())
                {
                    stack.Pop();
                }
                else if (commands[0] == "3" && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (commands[0] == "4" && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }


            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
