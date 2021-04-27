using System;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            char symboltoFind = char.Parse(Console.ReadLine());
            int symbolRow = 0;
            int symbolCol = 0;
            bool isFound = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    char current = matrix[row, col];
                    if (current == symboltoFind)
                    {
                        symbolRow = row;
                        symbolCol = col;
                        isFound = true;
                        break;
                    }
                    if (isFound)
                    {
                        break;
                    }
                }
            }

            if (isFound)
            {
                Console.WriteLine($"({symbolRow}, {symbolCol})");
            }
            else
            {
                Console.WriteLine($"{symboltoFind} does not occur in the matrix ");
            }
        }
    }
}
