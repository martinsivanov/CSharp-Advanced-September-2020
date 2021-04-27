using System;
using System.Linq;

namespace BookWarm
{
    class Program
    {
        static char[,] matrix;
        static int playerRow;
        static int playerCol;

        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];
            ReadMatrix(size);

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                matrix[playerRow, playerCol] = '-';
                int playerOldRow = playerRow;
                int playerOldCol = playerCol;
                CheckDirections(command);
                if (playerCol < 0 || playerCol >= matrix.GetLength(1)
                    || playerRow < 0 || playerRow >= matrix.GetLength(0))
                {
                    if (word.Any())
                    {
                        word = word.Remove(word.Length - 1);
                        matrix[playerOldRow, playerOldCol] = 'P';
                        playerRow = playerOldRow;
                        playerCol = playerOldCol;

                        continue;
                    }
                }
                else if (char.IsLetter(matrix[playerRow, playerCol]))
                {
                    word = word.Insert(word.Length, matrix[playerRow, playerCol].ToString());
                }

                if (playerCol >= 0 && playerCol < matrix.GetLength(1)
                    && playerRow >= 0 && playerRow < matrix.GetLength(0))
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            if (word != null)
            {
                Console.WriteLine(word);
            }

            PrintMatrix(size);
        }

        private static void CheckDirections(string command)
        {
            if (command == "up")
            {
                playerRow--;
            }
            else if (command == "down")
            {
                playerRow++;
            }
            else if (command == "left")
            {
                playerCol--;
            }
            else if (command == "right")
            {
                playerCol++;
            }
        }

        private static void ReadMatrix(int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
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
