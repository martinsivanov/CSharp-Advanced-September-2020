using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbersDivisible = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            DivisibleNumbers(numbersDivisible, n);

            Func<int[], int[]> func = DivisibleNumbers(numbersDivisible, n);

            int[] result = func(numbersDivisible);

            Console.WriteLine(String.Join(" ", result));

        }

        static Func<int[], int[]> DivisibleNumbers(int[] numbers, int n)
        {
            Func<int[], int[]> func = new Func<int[], int[]>((numbers) =>
            {
                HashSet<int> result = new HashSet<int>();

            for (int i = 1; i <= n; i++)
            {
                int counter = 0;
                int currentNum = i;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (currentNum % numbers[j] == 0)
                    {
                        counter++;
                    }
                }
                if (counter == numbers.Length)
                {
                    result.Add(currentNum);
                }

            }
            return result.ToArray();
        });

            return func;
        }
    }
}
