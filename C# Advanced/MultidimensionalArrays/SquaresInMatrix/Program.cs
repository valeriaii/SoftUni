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

            char[,] matrix = new char[rows, cols];

            int numOfSquares = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] inputEl = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < inputEl.Length; col++)
                {
                    matrix[row, col] = inputEl[col];

                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col + 1] &&
                            matrix[row, col] == matrix[row + 1, col])
                    {

                        numOfSquares++;

                    }
                }
            }
            Console.WriteLine(numOfSquares);
        }

    }
}

