using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][];

            for (int r = 0; r < rows; r++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                array[r] = currentRow;

            }
            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commands[0];
                if (command == "END")
                {
                    break;
                }
                else if (command == "Add")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    int value = int.Parse(commands[3]);

                    if (row < array.Length && row >= 0 && col >= 0)
                    {

                        array[row][col] += value;
                    }
                    else
                    {

                        Console.WriteLine("Invalid coordinates");
                    }

                }
                else if (command == "Subtract")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    int value = int.Parse(commands[3]);

                    if (row < array.Length && row >= 0 && col >= 0)
                    {
                        array[row][col] -= value;
                    }
                    else
                    {

                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            PrintJaggedArray(rows, array);
        }

        private static void PrintJaggedArray(int rows, int[][] array)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < array[row].Length; col++)
                {
                    Console.Write(array[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}