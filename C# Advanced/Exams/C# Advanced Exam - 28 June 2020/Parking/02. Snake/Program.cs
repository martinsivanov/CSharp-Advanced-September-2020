using System;

namespace _02._Snake
{
    class Program
    {
        static int snakeRow;
        static int snakeCol;
        static char[,] matrix;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowElement = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowElement[col];
                    if (matrix[row,col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            int foodCount = 0;
            bool isFeed = false;
            bool isOutSide = false;
            string command = Console.ReadLine();
            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';
                if (command == "up")
                {
                    snakeRow--;
                    if (snakeRow < 0)
                    {
                        isOutSide = true;
                        break;
                    }
                   
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;

                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        FindNextBarrel();
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                }
                else if (command == "down")
                {
                    snakeRow++;
                    if (snakeRow >= matrix.GetLength(0))
                    {
                        isOutSide = true;
                        break;
                    }
                    
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;

                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        FindNextBarrel();
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                }
                else if (command == "left")
                {
                    snakeCol--;
                    if (snakeCol < 0)
                    {
                        isOutSide = true;
                        break;
                    }
                    
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;

                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        FindNextBarrel();
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                }
                else if (command == "right")
                {
                    snakeCol++;
                    if (snakeRow >= matrix.GetLength(1))
                    {
                        isOutSide = true;
                        break;
                    }
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;

                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        FindNextBarrel();
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                }
                if (foodCount >= 10)
                {
                    isFeed = true;
                    break;
                }
                
                command = Console.ReadLine();
            }
            if (isFeed)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodCount}");
            }
            if (isOutSide)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {foodCount}");
            }
            PrintMatrix();

        }

        private static void FindNextBarrel()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
