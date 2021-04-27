using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            char[,] matrix = new char[input, input];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // 0 K 0 K 0
            // K 0 0 0 K
            // 0 0 K 0 0
            // K 0 0 0 K
            // 0 K 0 K 0
            int knightsCount = 0;
            int knightKills = 0;

            int counterKnights = 0;
            int maxRow = 0;
            int maxCol = 0;
            while (true)
            {
                int maxknightKills = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        knightKills = 0;

                        if (matrix[row, col] == 'K')
                        {
                            counterKnights++;
                            if (Inside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K') 
                                //  - 2 - 1
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')  
                                //  - 2 + 1
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K') 
                                //  + 2 - 1
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                                //  + 2 + 1
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K') 
                                //  + 1 + 2
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')  
                                //  + 1 - 2
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')  
                                //  - 1 - 2
                            {
                                knightKills++;
                            }
                            if (Inside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K') 
                                //  - 1 + 2
                            {
                                knightKills++;
                            }
                            if (knightKills > maxknightKills)
                            {
                                maxknightKills = knightKills;
                                maxRow = row;
                                maxCol = col;

                            }
                        }


                    }
                }
                if (maxknightKills > 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    knightsCount++;
                }
                else
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }
        }

        private static bool Inside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

    }
}
