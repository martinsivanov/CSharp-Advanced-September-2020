using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];


            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int sumMatrix = 0;
            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            //  1 5 5 2 4
            //  2 1 4 14 3
            //  3 7 11 2 8
            //  4 8 12 16 4

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sumRowOne = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int sumRowTwo = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int sumRowThree = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    sumMatrix = sumRowOne + sumRowTwo + sumRowThree;
                    if (sumMatrix > bestSum)
                    {
                        bestSum = sumMatrix;
                        bestRow = row;
                        bestCol = col;

                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            for (int r = bestRow; r < bestRow + 3; r++)
            {
                for (int c = bestCol; c < bestCol + 3; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
