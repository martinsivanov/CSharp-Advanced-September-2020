using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            ReadMatrix(matrix, rows, cols);

            int allCoalsCount = 0;
            int rowPlayer = 0;
            int colPlayer = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        allCoalsCount++;
                    }
                }
            }

            bool gameOver = false;
            bool collectAll = false;
            int currentCoals = allCoalsCount;
            foreach (var command in commands)
            {
                if (command == "left")
                {
                    if (Inside(matrix, rowPlayer, colPlayer - 1))
                    {
                        // S
                        if (matrix[rowPlayer, colPlayer - 1] == 'c')
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer, colPlayer - 1] = current;
                            matrix[rowPlayer, colPlayer] = '*';
                            currentCoals--;
                            colPlayer -= 1;

                            if (currentCoals == 0)
                            {
                                collectAll = true;
                                break;
                            }
                        }
                        else if (matrix[rowPlayer, colPlayer - 1] == 'e')
                        {
                            colPlayer -= 1;
                            gameOver = true;
                            break;
                        }
                        else
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer, colPlayer - 1] = current;
                            colPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = '*';

                        }

                    }
                }
                if (command == "right")
                {
                    if (Inside(matrix, rowPlayer, colPlayer + 1))
                    {
                        if (matrix[rowPlayer, colPlayer + 1] == 'c')
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer, colPlayer + 1] = current;
                            colPlayer += 1;
                            matrix[rowPlayer, colPlayer] = '*';
                            currentCoals--;
                            if (currentCoals == 0)
                            {
                                collectAll = true;
                                break;
                            }
                        }
                        else if (matrix[rowPlayer, colPlayer + 1] == 'e')
                        {
                            colPlayer += 1;
                            gameOver = true;
                            break;
                        }
                        else
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer, colPlayer + 1] = current;
                            colPlayer += 1;
                            matrix[rowPlayer, colPlayer] = '*';

                        }
                    }
                }
                if (command == "up")
                {
                    if (Inside(matrix, rowPlayer - 1, colPlayer))
                    {
                        if (matrix[rowPlayer - 1, colPlayer] == 'c')
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer - 1, colPlayer] = current;
                            matrix[rowPlayer, colPlayer] = '*';
                            rowPlayer -= 1;
                            currentCoals--;
                            if (currentCoals == 0)
                            {
                                collectAll = true;
                                break;
                            }
                        }
                        else if (matrix[rowPlayer - 1, colPlayer] == 'e')
                        {
                            rowPlayer -= 1;
                            gameOver = true;
                            break;
                        }
                        else
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer - 1, colPlayer] = current;
                            matrix[rowPlayer, colPlayer] = '*';
                            rowPlayer -= 1;

                        }
                    }
                }
                if (command == "down")
                {
                    if (Inside(matrix, rowPlayer + 1, colPlayer))
                    {
                        if (matrix[rowPlayer + 1, colPlayer] == 'c')
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer + 1, colPlayer] = current;
                            matrix[rowPlayer, colPlayer] = '*';
                            currentCoals--;
                            rowPlayer += 1;
                            if (currentCoals == 0)
                            {
                                collectAll = true;
                                break;
                            }
                        }
                        else if (matrix[rowPlayer + 1, colPlayer] == 'e')
                        {
                            rowPlayer += 1;
                            gameOver = true;
                            break;
                        }
                        else
                        {
                            char current = matrix[rowPlayer, colPlayer];
                            matrix[rowPlayer + 1, colPlayer] = current;
                            matrix[rowPlayer, colPlayer] = '*';
                            rowPlayer += 1;

                        }
                    }
                }

            }
            if (gameOver)
            {
                Console.WriteLine($"Game over! ({rowPlayer}, {colPlayer})");
            }
            if (collectAll)
            {
                Console.WriteLine($"You collected all coals! ({rowPlayer}, {colPlayer})");
            }
            if (!gameOver && !collectAll)
            {
                Console.WriteLine($"{currentCoals} coals left. ({rowPlayer}, {colPlayer})");
            }
        }

        private static bool Inside(char[,] matrix, int rowPlayer, int colPlayer)
        {
            return rowPlayer >= 0 && rowPlayer < matrix.GetLength(0) && colPlayer >= 0 && colPlayer < matrix.GetLength(1);
        }

        private static void ReadMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
        }
    }
}
