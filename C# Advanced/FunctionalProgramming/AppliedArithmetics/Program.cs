using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string operation = Console.ReadLine();
            int[] result = inputIntegers;
            Func<int[], int[]> calcMethod = GetCalcMethod(operation);
            while (operation != "end")
            {
                
                if (operation == "print")
                {
                    Console.WriteLine(string.Join(" ",inputIntegers));
                    operation = Console.ReadLine();
                    continue;
                }
                inputIntegers = calcMethod(inputIntegers);
                operation = Console.ReadLine();
                calcMethod = GetCalcMethod(operation);

            }

        }
        static Func<int[], int[]> GetCalcMethod(string input)
        {
            switch (input)
            {
                case "add":
                    return Add;
                case "multiply":
                    return Multiply;
                case "subtract":
                    return Substract;

                default:
                    break;
            }
            return null;
        }



        private static int[] Substract(int[] arg)
        {
            return arg = arg.Select(x => x - 1).ToArray();
        }

        private static int[] Multiply(int[] arg)
        {
            return arg = arg.Select(x => x * 2).ToArray();
        }

        private static int[] Add(int[] arg)
        {
            return arg = arg.Select(x => x + 1).ToArray();
        }
    }
}
