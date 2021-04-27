using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = (arr) =>
            {
                Console.WriteLine(String.Join(" ",arr));
            };
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int[], int[]> func = GetFunc(command);
                    numbers = func(numbers);

                }



                command = Console.ReadLine();
            }

        }

        static Func<int[], int[]> GetFunc(string command)
        {
            Func<int[], int[]> proccesor = null;
            if (command == "add") //"multiply" -> multiply each number by 2
            {
                proccesor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]++;
                    }
                    return arr;
                });
            }
            else if (command == "multiply")
            {
                proccesor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] *= 2;
                    }
                    return arr;
                });
            }
            else if (command == "subtract")
            {
                proccesor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] -= 1;
                    }
                    return arr;
                });
            }
            return proccesor;
        }
    }
}
