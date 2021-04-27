using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static char[,] matrix;
        static int santaRow;
        static int santaCol;

        static void Main(string[] args)
        {
            int countsPresents = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];
            int countNiceKidsLeft = 0;

            ReadMatrixAndFindSanta(size);

            string command = Console.ReadLine();
            int niceKidsPresents = 0;
            bool isRanOut = false;
            while (command != "Christmas morning")
            {
                matrix[santaRow, santaCol] = '-';
                if (command == "up")
                {
                    santaRow--;
                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        countsPresents--;
                        countNiceKidsLeft++;
                    }
                    else if (matrix[santaRow, santaCol] == 'X')
                    {

                    }
                    else if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] != '-')
                        {

                            if (matrix[santaRow - 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow - 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow - 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow + 1, santaCol] != '-')
                        {
                            
                            if (matrix[santaRow + 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow + 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow + 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol - 1] != '-')
                        {
                            
                            if ((matrix[santaRow, santaCol - 1] == 'V'))
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol - 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol-1] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol + 1] != '-')
                        {
                            if (matrix[santaRow, santaCol + 1] == 'V')
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol + 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol + 1] = '-';
                                countsPresents--;
                            }
                        }
                    }
                }
                else if (command == "down")
                {

                    santaRow++;
                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        countsPresents--;
                        niceKidsPresents++;
                    }
                    else if (matrix[santaRow, santaCol] == 'X')
                    {

                    }
                    else if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] != '-')
                        {

                            if (matrix[santaRow - 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow - 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow - 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow + 1, santaCol] != '-')
                        {

                            if (matrix[santaRow + 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow + 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow + 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol - 1] != '-')
                        {

                            if ((matrix[santaRow, santaCol - 1] == 'V'))
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol - 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol - 1] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol + 1] != '-')
                        {
                            if (matrix[santaRow, santaCol + 1] == 'V')
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol + 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol + 1] = '-';
                                countsPresents--;
                            }
                        }
                    }
                }
                else if (command == "left")
                {

                    santaCol--;
                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        countsPresents--;
                        niceKidsPresents++;
                    }
                    else if (matrix[santaRow, santaCol] == 'X')
                    {

                    }
                    else if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] != '-')
                        {

                            if (matrix[santaRow - 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow - 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow - 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow + 1, santaCol] != '-')
                        {

                            if (matrix[santaRow + 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow + 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow + 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol - 1] != '-')
                        {

                            if ((matrix[santaRow, santaCol - 1] == 'V'))
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol - 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol - 1] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol + 1] != '-')
                        {
                            if (matrix[santaRow, santaCol + 1] == 'V')
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol + 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol + 1] = '-';
                                countsPresents--;
                            }
                        }
                    }
                }
                else if (command == "right")
                {

                    santaCol++;
                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        countsPresents--;
                        niceKidsPresents++;
                    }
                    else if (matrix[santaRow, santaCol] == 'X')
                    {

                    }
                    else if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] != '-')
                        {

                            if (matrix[santaRow - 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow - 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow - 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow + 1, santaCol] != '-')
                        {

                            if (matrix[santaRow + 1, santaCol] == 'V')
                            {
                                countsPresents--;
                                niceKidsPresents++;
                                matrix[santaRow + 1, santaCol] = '-';
                            }
                            else
                            {
                                matrix[santaRow + 1, santaCol] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol - 1] != '-')
                        {

                            if ((matrix[santaRow, santaCol - 1] == 'V'))
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol - 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol - 1] = '-';
                                countsPresents--;
                            }
                        }
                        if (matrix[santaRow, santaCol + 1] != '-')
                        {
                            if (matrix[santaRow, santaCol + 1] == 'V')
                            {
                                niceKidsPresents++;
                                countsPresents--;
                                matrix[santaRow, santaCol + 1] = '-';
                            }
                            else
                            {
                                matrix[santaRow, santaCol + 1] = '-';
                                countsPresents--;
                            }
                        }
                    }
                }

                matrix[santaRow, santaCol] = 'S';
                if (countsPresents == 0)
                {
                    isRanOut = true;
                    break;
                }
                command = Console.ReadLine();
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        countNiceKidsLeft++;
                    }
                }
            }

            if (isRanOut)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            PrintMatrix(size);
            if (countNiceKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsPresents} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {countNiceKidsLeft} nice kid/s.");
            }
        }

        private static void PrintMatrix(int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadMatrixAndFindSanta(int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().Split().Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (matrix[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }

                }
            }
        }

    }
}
