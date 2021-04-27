using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            int sumFirst = 0;

            for (int row = 0; row < n; row++)
            {

                sumFirst += matrix[row, row];

            }
            int sumSecond = 0;
            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                sumSecond += matrix[row, col];
            }

            int difference = sumSecond - sumFirst;
            Console.WriteLine(Math.Abs(difference));
        }

        private static void PrintMatrix(int n, int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
