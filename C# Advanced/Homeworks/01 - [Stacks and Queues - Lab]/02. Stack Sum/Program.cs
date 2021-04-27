using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            var input = Console.ReadLine();

            while (true)
            {

                var command = input.ToLower().Split().ToArray();

                if (command.Contains("add"))
                {
                    int firstNum = int.Parse(command[1]);
                    int secondNum = int.Parse(command[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command.Contains("remove"))
                {
                    int num = int.Parse(command[1]);
                    if (num < stack.Count)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");


        }
    }
}
