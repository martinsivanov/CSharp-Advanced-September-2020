using System;

namespace Bee
{
    class Program
    {
        static char[,] matrix;
        static int beeRow;
        static int beeCol;



        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }

                }
            }

            int countFlowers = 0;
            bool beeLost = false;
            string command = Console.ReadLine();
            while (command != "End")
            {

                if (command == "up")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow--;
                    if (beeRow < 0)
                    {
                        beeLost = true;
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        countFlowers++;
                        matrix[beeRow, beeCol] = 'B';

                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow--;
                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            countFlowers++;
                            matrix[beeRow, beeCol] = 'B';

                        }
                        else
                        {
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = 'B';
                    }

                }
                else if (command == "down")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow++;
                    if (beeRow >= matrix.GetLength(0))
                    {
                        beeLost = true;
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        countFlowers++;
                        matrix[beeRow, beeCol] = 'B';

                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow++;
                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            countFlowers++;
                            matrix[beeRow, beeCol] = 'B';

                        }
                        else
                        {
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = 'B';
                    }
                }
                else if (command == "left")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol--;
                    if (beeCol < 0)
                    {
                        beeLost = true;
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        countFlowers++;
                        matrix[beeRow, beeCol] = 'B';

                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeCol--;
                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            countFlowers++;
                            matrix[beeRow, beeCol] = 'B';

                        }
                        else
                        {
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = 'B';
                    }
                }
                else if (command == "right")
                {

                    matrix[beeRow, beeCol] = '.';
                    beeCol++;
                    if (beeCol >= matrix.GetLength(1))
                    {
                        beeLost = true;
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        countFlowers++;
                        matrix[beeRow, beeCol] = 'B';

                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeCol++;
                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            countFlowers++;
                            matrix[beeRow, beeCol] = 'B';

                        }
                        else
                        {
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = 'B';
                    }
                }

                command = Console.ReadLine();
            }

            if (beeLost)
            {
                Console.WriteLine("The bee got lost!");
                if (countFlowers >= 5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {countFlowers} flowers!");
                    PrintMatrix(size);
                }
                else
                {
                    int needed = 5 - countFlowers;
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {needed} flowers more");
                    PrintMatrix(size);
                }
            }
            else
            {
                if (countFlowers >= 5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {countFlowers} flowers!");
                    PrintMatrix(size);
                }
                else
                {
                    int needed = 5 - countFlowers;
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {needed} flowers more");
                    PrintMatrix(size);
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
