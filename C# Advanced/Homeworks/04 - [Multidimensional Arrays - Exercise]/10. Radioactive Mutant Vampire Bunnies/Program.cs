using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static char[,] matrix;
        static int playerRow;
        static int playerCol;
        static bool isDead;

        static void Main(string[] args)
        {
            isDead = false;

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];
            matrix = new char[rows, cols];

            ReadMatrix(rows, cols, matrix);

            char[] directions = Console.ReadLine().ToCharArray();


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            foreach (var direction in directions)
            {
                if (direction == 'U')
                {
                    Move(-1, 0);
                }
                else if (direction == 'D')
                {
                    Move(1, 0);
                }
                else if (direction == 'R')
                {
                    Move(0, +1);
                }
                else if (direction == 'L')
                {
                    Move(0, -1);
                }

                Spread();


            }


            if (isDead)
            {
                Print();
                Console.WriteLine($"dead: {playerCol} {playerRow}");
                Environment.Exit(0);
            }


        }

        private static void Spread()
        {
            List<int> bunnysCd = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnysCd.Add(row);
                        bunnysCd.Add(col);
                    }

                }
            }

            for (int i = 0; i < bunnysCd.Count; i += 2)
            {
                int bunnyRow = bunnysCd[i];
                int bunnyCol = bunnysCd[i + 1];

                //Right
                if (IsInside(bunnyRow, bunnyCol + 1))
                {
                    if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                    {
                        // DIE
                        isDead = true;
                    }

                    matrix[bunnyRow, bunnyCol + 1] = 'B';

                }
                // LEFT
                if (IsInside(bunnyRow, bunnyCol - 1))
                {
                    if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                    {
                        // DIE
                        isDead = true;
                    }

                    matrix[bunnyRow, bunnyCol - 1] = 'B';

                }
                // UP
                if (IsInside(bunnyRow - 1, bunnyCol))
                {
                    if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                    {
                        // DIE
                        isDead = true;
                    }

                    matrix[bunnyRow - 1, bunnyCol] = 'B';

                }
                // DOWN
                if (IsInside(bunnyRow + 1, bunnyCol))
                {
                    if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                    {
                        // DIE
                        isDead = true;
                    }

                    matrix[bunnyRow + 1, bunnyCol] = 'B';

                }
            }
        }

        private static void Move(int row, int col)
        {
            if (IsInside(playerRow + row, playerCol + col))
            {
                if (matrix[playerRow + row, playerCol + col] == 'B')
                {
                    isDead = true;

                    Spread();
                    Print();
                    playerRow += row;
                    playerCol += col;
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }
                if (matrix[playerRow + row, playerCol + col] == '.')
                {
                    matrix[playerRow, playerCol] = '.';
                    playerRow += row;
                    playerCol += col;
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                matrix[playerRow, playerCol] = '.';

                Spread();
                Print();
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }
        }

        private static void Print()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }


        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
        }
    }
}
