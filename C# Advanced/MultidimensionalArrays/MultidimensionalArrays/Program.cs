using System;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int[,] matrix = new int[n, n];
            int sumPrimary = 0;
            int sumSeconadry = 0;

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                    if (row == col)
                    {
                        sumPrimary += matrix[row, col];
                    }
                    if (row + col == n-1)
                    {
                        sumSeconadry += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumPrimary - sumSeconadry));


        }
    }
}
