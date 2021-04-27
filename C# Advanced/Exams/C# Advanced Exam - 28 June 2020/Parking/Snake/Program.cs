using System;

namespace Snake
{
    class Program
    {
        static char[][] field;
        static int playerRow;
        static int playerCol;
        static bool isGameOver = false;
        static int countFood = 0;
        static bool isFed = false;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            field = new char[size][];
            ReadFieldAndFindPlayer();

            


            while (true)
            {
                string movement = Console.ReadLine();
                field[playerRow][playerCol] = '.';
                if (movement == "up")
                {
                    IsSnakeOutSide(playerRow - 1);
                    if (isGameOver)
                    {
                        break;
                    }
                    playerRow--;
                    CheckForFood();
                    if (field[playerRow][playerCol] == 'B')
                    {
                        FindNextBurrow();
                    }
                }
                else if (movement == "down")
                {
                    IsSnakeOutSide(playerRow + 1);
                    if (isGameOver)
                    {
                        break;
                    }
                    playerRow++;
                    CheckForFood();
                    if (field[playerRow][playerCol] == 'B')
                    {
                        FindNextBurrow();
                    }
                }
                else if (movement == "left")
                {
                    IsSnakeOutSide(playerCol - 1);
                    if (isGameOver)
                    {
                        break;
                    }
                    playerCol--;
                    CheckForFood();
                    if (field[playerRow][playerCol] == 'B')
                    {
                        FindNextBurrow();
                    }
                }
                else if (movement == "right")
                {
                    IsSnakeOutSide(playerCol + 1);
                    if (isGameOver)
                    {
                        break;
                    }
                    playerCol++;
                    CheckForFood();
                    if (field[playerRow][playerCol] == 'B')
                    {
                        FindNextBurrow();
                    }
                }
                if (isFed)
                {
                    break;
                }
               
                field[playerRow][playerCol] = 'S';

            }
            if (isGameOver)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {countFood}");
                PrintField();
            }
            if (isFed)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {countFood}");
                PrintField();
            }

        }
     
        private static void FindNextBurrow()
        {
            field[playerRow][playerCol] = '.';
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'B')
                    {
                        
                        playerRow = row;
                        playerCol = col;

                    }
                }
            }
        }

        private static void CheckForFood()
        {
            if (field[playerRow][playerCol] == '*')
            {
                countFood++;
                if (countFood == 10)
                {
                    field[playerRow][playerCol] = 'S';
                    isFed = true;

                }
                
            }
        }

        private static void IsSnakeOutSide(int position)
        {
            if (position < 0 || position >= field.Length)
            {
                isGameOver = true;
                field[playerRow][playerCol] = '.';
            }
        }

        private static void ReadFieldAndFindPlayer()
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();
                field[row] = new char[rowElements.Length];
                for (int col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = rowElements[col];
                    if (field[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }

            }
        }

        private static void PrintField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
