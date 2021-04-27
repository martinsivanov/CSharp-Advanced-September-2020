using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            ReadMatrix(matrix, rows, cols);

            var coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var bomb in coordinates)
            {
                int[] bombCordinate = bomb.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowCurrentBomb = bombCordinate[0];
                int colCurrentBomb = bombCordinate[1];
                int currentBombValue = matrix[rowCurrentBomb, colCurrentBomb];
                matrix[rowCurrentBomb, colCurrentBomb] = 0;


                // -1   0
                if (Inside(matrix, rowCurrentBomb - 1, colCurrentBomb) && matrix[rowCurrentBomb - 1, colCurrentBomb] > 0)
                {
                    matrix[rowCurrentBomb - 1, colCurrentBomb] -= currentBombValue;
                }
                // -1 + 1
                if (Inside(matrix, rowCurrentBomb - 1, colCurrentBomb + 1) && matrix[rowCurrentBomb - 1, colCurrentBomb + 1] > 0)
                {
                    matrix[rowCurrentBomb - 1, colCurrentBomb + 1] -= currentBombValue;
                }
                // -1 - 1
                if (Inside(matrix, rowCurrentBomb - 1, colCurrentBomb - 1) && matrix[rowCurrentBomb - 1, colCurrentBomb - 1] > 0)
                {
                    matrix[rowCurrentBomb - 1, colCurrentBomb - 1] -= currentBombValue;
                }
                //  0 + 1
                if (Inside(matrix, rowCurrentBomb, colCurrentBomb + 1) && matrix[rowCurrentBomb, colCurrentBomb + 1] > 0)
                {
                    matrix[rowCurrentBomb, colCurrentBomb + 1] -= currentBombValue;
                }
                //  0 - 1
                if (Inside(matrix, rowCurrentBomb, colCurrentBomb - 1) && matrix[rowCurrentBomb, colCurrentBomb - 1] > 0)
                {
                    matrix[rowCurrentBomb, colCurrentBomb - 1] -= currentBombValue;
                }
                //  +1  0
                if (Inside(matrix, rowCurrentBomb + 1, colCurrentBomb) && matrix[rowCurrentBomb + 1, colCurrentBomb] > 0)
                {
                    matrix[rowCurrentBomb + 1, colCurrentBomb] -= currentBombValue;
                }
                // + 1 -1
                if (Inside(matrix, rowCurrentBomb + 1, colCurrentBomb - 1) && matrix[rowCurrentBomb + 1, colCurrentBomb - 1] > 0)
                {
                    matrix[rowCurrentBomb + 1, colCurrentBomb - 1] -= currentBombValue;
                }
                // + 1 +1
                if (Inside(matrix, rowCurrentBomb + 1, colCurrentBomb + 1) && matrix[rowCurrentBomb + 1, colCurrentBomb + 1] > 0)
                {
                    matrix[rowCurrentBomb + 1, colCurrentBomb + 1] -= currentBombValue;
                }


            }
            int sum = 0;
            int aliveCells = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }


        }

        private static bool Inside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadMatrix(int[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }

            }
        }
    }
}
