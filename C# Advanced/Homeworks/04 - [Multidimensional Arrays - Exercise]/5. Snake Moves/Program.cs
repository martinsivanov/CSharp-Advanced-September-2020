using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string text = Console.ReadLine();

            char[,] matrix = new char[rows, cols];


            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] textChars = text.ToCharArray();
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = textChars[counter];
                        counter++;
                        if (counter >= textChars.Length)
                        {
                            counter = 0;

                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = textChars[counter];
                        counter++;
                        if (counter >= textChars.Length)
                        {
                            counter = 0;

                        }
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
