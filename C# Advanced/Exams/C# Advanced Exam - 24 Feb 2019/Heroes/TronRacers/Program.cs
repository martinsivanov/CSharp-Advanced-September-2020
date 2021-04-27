using System;
using System.Linq;

namespace TronRacers
{
    class Program
    {
        static char[,] matrix;
        static int firstRow;
        static int firstCol;
        static int secondRow;
        static int secondCol;


        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];
            ReadMatrixAndFindPlayers(size);
            bool firstDead = false;
            bool secondDead = false;
            while (true)
            {
                string[] commands = Console.ReadLine().Split().ToArray();
                string firstCommand = commands[0];
                string secondCommand = commands[1];
                // FirstPlayer moves

                FirstPlayerMoves(firstCommand);

                if (matrix[firstRow, firstCol] == 's')
                {
                    firstDead = true;
                    matrix[firstRow, firstCol] = 'x';
                    break;
                }
                matrix[firstRow, firstCol] = 'f';
                SecondPlayerMoves(secondCommand);
                if (matrix[secondRow,secondCol] == 'f')
                {
                    secondDead = true;
                    matrix[secondRow, secondCol] = 'x';
                    break;
                }
                matrix[secondRow, secondCol] = 's';
                //Console.WriteLine();
                //PrintMatrix(size);
            }
            PrintMatrix(size);

        }

        private static void SecondPlayerMoves(string secondCommand)
        {
            if (secondCommand == "up")
            {
                secondRow--;
                if (secondRow < 0)
                {
                    secondRow = matrix.GetLength(0) - 1;
                }

            }
            else if (secondCommand == "down")
            {
                secondRow++;
                if (secondRow > matrix.GetLength(0) - 1)
                {
                    secondRow = 0;
                }
            }
            else if (secondCommand == "left")
            {
                secondCol--;
                if (secondCol < 0)
                {
                    secondCol = matrix.GetLength(1) - 1;
                }
            }
            else if (secondCommand == "right")
            {
                secondCol++;
                if (secondCol > matrix.GetLength(1) - 1)
                {
                    secondCol = 0;
                }
            }
        }

        private static void FirstPlayerMoves(string firstCommand)
        {
            if (firstCommand == "up")
            {
                firstRow--;
                if (firstRow < 0)
                {
                    firstRow = matrix.GetLength(0) - 1;
                }
            }
            else if (firstCommand == "down")
            {
                firstRow++;
                if (firstRow > matrix.GetLength(0) - 1)
                {
                    firstRow = 0;
                }
            }
            else if (firstCommand == "left")
            {
                firstCol--;
                if (firstCol < 0)
                {
                    firstCol = matrix.GetLength(1) - 1;
                }

            }
            else if (firstCommand == "right")
            {
                firstCol++;
                if (firstCol > matrix.GetLength(1) - 1)
                {
                    firstCol = 0;
                }
            }
        }

        private static void ReadMatrixAndFindPlayers(int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (matrix[row, col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }
        }

        private static void PrintMatrix(int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
