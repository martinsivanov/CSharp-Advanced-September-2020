using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] col = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArray[row] = col;

            }

            Analiz(jaggedArray);
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = inputInfo[0];

                if (command == "Add")
                {
                    int row = int.Parse(inputInfo[1]);
                    int col = int.Parse(inputInfo[2]);
                    int value = int.Parse(inputInfo[3]);

                    if (IsValid(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] += value;
                    }

                }
                else if (command == "Subtract")
                {

                    int row = int.Parse(inputInfo[1]);
                    int col = int.Parse(inputInfo[2]);
                    int value = int.Parse(inputInfo[3]);
                    if (IsValid(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }


            foreach (double[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

        private static bool IsValid(double[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }

        private static void Analiz(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                double[] col = jaggedArray[row];
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {

                    for (int c = 0; c < jaggedArray[row].Length; c++)
                    {
                        jaggedArray[row][c] *= 2;
                    }
                    for (int c = 0; c < jaggedArray[row + 1].Length; c++)
                    {
                        jaggedArray[row + 1][c] *= 2;
                    }

                }
                else
                {
                    for (int c = 0; c < jaggedArray[row].Length; c++)
                    {
                        jaggedArray[row][c] /= 2;
                    }
                    for (int c = 0; c < jaggedArray[row + 1].Length; c++)
                    {
                        jaggedArray[row + 1][c] /= 2;
                    }
                }
            }
        }
    }
}
