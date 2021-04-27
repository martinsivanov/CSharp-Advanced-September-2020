using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static char[,] field;
        static int playerRow;
        static int playerCol;


        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int countOfCommands = int.Parse(Console.ReadLine());
            field = new char[size, size];
            ReadFieldAndFindPlayer(size);


            bool isWin = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string commandInfo = Console.ReadLine();
                field[playerRow, playerCol] = '-';
                if (commandInfo == "up")
                {
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = field.GetLength(0) - 1;
                    }
                    if (field[playerRow, playerCol] == 'B')
                    {
                        playerRow--;
                        CheckIfOutSide();
                    }
                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerRow++;
                    }
                    if (field[playerRow, playerCol] == 'F')
                    {
                        field[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }
                }
                else if (commandInfo == "down")
                {
                    playerRow++;
                    if (playerRow > field.GetLength(0) - 1)
                    {
                        playerRow = 0;
                    }
                    if (field[playerRow, playerCol] == 'B')
                    {
                        playerRow++;
                        CheckIfOutSide();
                    }
                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerRow--;
                    }
                    if (field[playerRow, playerCol] == 'F')
                    {
                        field[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }
                }
                else if (commandInfo == "left")
                {
                    playerCol--;
                    CheckIfOutSide();
                    if (field[playerRow, playerCol] == 'B')
                    {
                        playerCol--;
                        CheckIfOutSide();
                    }
                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerCol++;
                    }
                    if (field[playerRow, playerCol] == 'F')
                    {
                        field[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }
                }
                else if (commandInfo == "right")
                {
                    playerCol++;
                    if (playerCol > field.GetLength(1) - 1)
                    {
                        playerCol = 0;
                    }
                    if (field[playerRow, playerCol] == 'B')
                    {
                        playerCol++;
                        CheckIfOutSide();
                    }
                    if (field[playerRow, playerCol] == 'T')
                    {
                        playerCol--;
                    }
                    if (field[playerRow, playerCol] == 'F')
                    {
                        field[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }
                }

                field[playerRow, playerCol] = 'f';
            }

            if (isWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }
            PrintField(size);
        }

        private static void CheckIfOutSide()
        {
            if (playerCol < 0)
            {
                playerCol = field.GetLength(1) - 1;
            }
        }

        private static void PrintField(int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ReadFieldAndFindPlayer(int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowElements[col];
                    if (field[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }

            }
        }
    }
}
