using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = ReadJaggedArray(rows);

            for (int row = 0; row < rows - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                   
                        jagged[row] = Multiplier(jagged[row]);
                        jagged[row + 1] = Multiplier(jagged[row+1]);
                    
                }
                else if (jagged[row].Length != jagged[row + 1].Length)
                {
                   
                        jagged[row] = Divider(jagged[row]);
                        jagged[row + 1]= Divider(jagged[row+1]);
                   
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                var input = command.Split();
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int val = int.Parse(input[3]);
                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                {
                    command = Console.ReadLine();
                    continue;
                }
                else if (input[0] == "Add")
                {
                    jagged[row][col] += val;
                }
                else if (input[0] == "Subtract")
                {
                    jagged[row][col] -= val;
                }
                command = Console.ReadLine();
            }
            PrintJagged(jagged);
        }

        static double[][] ReadJaggedArray(int rows)
        {
            double[][] jagged = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }
            return jagged;
        }
        static void PrintJagged(double[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine($"{String.Join(" ", jagged[row])}");
            }

        }
        static double[] Multiplier(double[] jagged)
        {
           return jagged = jagged
            .Select(x => x * 2)
            .ToArray();
        }

         static double[] Divider(double[] jagged)
        {
            return jagged = jagged
            .Select(x => x / 2)
            .ToArray();
        }
    }
}
