using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }

            }
            int squareSum = 0;
            int bestSum = int.MinValue;

            int[,] square = new int[2, 2];

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    squareSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (bestSum < squareSum)
                    {
                        square[0, 0] = matrix[row, col];
                        square[1, 0] = matrix[row + 1, col];
                        square[0, 1] = matrix[row, col + 1];
                        square[1, 1] = matrix[row + 1, col + 1];
                        bestSum = squareSum;
                    }
                }

            }

            PrintMatrix(2, 2, square);
            Console.WriteLine(bestSum);
        }

        private static void PrintMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
