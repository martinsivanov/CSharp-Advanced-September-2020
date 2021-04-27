using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> func = GetSmallest;
            
            Console.WriteLine(func(numbers));
        }

        static int GetSmallest(int[] numbers)
        {
            int minValue = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int current = numbers[i];
                if (current < minValue)
                {
                    minValue = current;

                }
            }
            return minValue;
        }
    }
}
