using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }

            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArgs[0] == "swap" && commandArgs.Length == 5)
                {
                    int firstRow = int.Parse(commandArgs[1]);
                    int firstCol = int.Parse(commandArgs[2]);
                    int secondRow = int.Parse(commandArgs[3]);
                    int secondCol = int.Parse(commandArgs[4]);

                    if (firstRow >= 0 && firstRow < rows && firstCol >= 0 && firstCol < cols &&
                        secondRow >= 0 && secondRow < rows && secondCol >= 0 && secondCol < cols)
                    {
                        string temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        PrintMatrix(rows, cols, matrix);

                    }
                    else
                    {

                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }


        }

        private static void PrintMatrix(int rows, int cols, string[,] matrix)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
