using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var values = input.Split();

            var stack = new Stack<string>(values.Reverse());

            while (stack.Count > 1)
            {
                var first = int.Parse(stack.Pop());
                var operatorr = stack.Pop();
                var second = int.Parse(stack.Pop());

                if (operatorr == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else if (operatorr == "-")
                {
                    stack.Push((first - second).ToString());
                }
            }
            Console.WriteLine(stack.Pop());


        }
    }
}
