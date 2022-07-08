using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] dna = new int[sequenceLength];
            int dnaSum = 0;
            int dnaCount = -1;//винаги подсигурява че сме вътре в масива
            int dnaStartIndex = -1;
            int dnaSamples = 0;

            int sample = 0;//текущи проби
            while (input!="Clone them!")
            {
                //насточщо инфо
                sample++;
                int[] currDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).ToArray();
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                bool isCurrDnaBetter = false;
                int currDnaSum = 0;

                int count = 0;//ппродължителост
                for (int i = 0; i < currDna.Length; i++)
                {
                    if (currDna[i]!=1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count>currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }

                }
                //01101=> 11(endindex=2)==>startindex=2-2+1=1
                currStartIndex = currEndIndex - currCount + 1;
                //01101.Sum()=>3
                currDnaSum = currDna.Sum();
                //check curr dna with best dna
                if (currCount>dnaCount)
                {
                    isCurrDnaBetter = true;
                }
                else if (currCount==dnaCount)
                {
                    if (currStartIndex<dnaStartIndex)
                    {
                        isCurrDnaBetter = true;

                    }
                    else if (currStartIndex==dnaStartIndex)
                    {
                        if (currDnaSum>dnaSum)
                        {
                            isCurrDnaBetter = true;
                        }
                    }
                }
                if (isCurrDnaBetter)
                {
                    dna = currDna;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    dnaSamples = sample;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(String.Join(" ",dna));


        }
    }
}
