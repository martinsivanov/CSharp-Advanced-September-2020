using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            Func< List<int>, List<int>> func = RemoveElementsDivisibleToN(n);
            numbers = func(numbers);
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }



        }

        static Func<List<int>, List<int>> RemoveElementsDivisibleToN(int n)
        {
            Func<List<int>, List<int>> func = new Func<List<int>, List<int>>((numbers) =>
            {
                List<int> result = new List<int>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % n != 0)
                    {
                        result.Add(numbers[i]);
                    }
                }

                return result;
            });

            return func;
        }
    }
}
