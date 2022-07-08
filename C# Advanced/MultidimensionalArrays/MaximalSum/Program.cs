using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];



            for (int row = 0; row < rows; row++)
            {
                int[] inputEl = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < inputEl.Length; col++)
                {
                    matrix[row, col] = inputEl[col];

                }
            }
            int maxSum = 0;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col] +
                        matrix[row + 2, col] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 2, col + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxSumCol = col;
                        maxSumRow = row;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxSumRow; row < maxSumRow + 3; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

    }
}

