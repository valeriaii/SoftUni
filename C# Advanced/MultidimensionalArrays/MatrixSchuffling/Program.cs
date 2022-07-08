using System;
using System.Linq;

namespace MatrixSchuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];



            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputEl = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputEl[col];

                }
            }

            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "END")
            {

                if (command[0] == "swap" && command.Length == 5)
                {
                    int row1 = int.Parse(command[1]);
                    int row2 = int.Parse(command[3]);
                    int col1 = int.Parse(command[2]);
                    int col2 = int.Parse(command[4]);
                    if (row1 >= rows ||
                        row2 >= rows ||
                        col1 >= cols ||
                         col2 >= cols)
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    string temp;
                    temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2]; ;
                    matrix[row2, col2] = temp;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine().Split().ToArray();



            }
        }
    }
}
