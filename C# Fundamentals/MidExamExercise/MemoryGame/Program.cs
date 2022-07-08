using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(",").ToList();
            string input = Console.ReadLine();
            int moves = 0;
            while (true)
            {
                if (input == "end")
                {
                    break;
                }
                string[] indexes = input.Split();
                int ind1 = int.Parse(indexes[0]);
                int ind2 = int.Parse(indexes[1]);
                moves++;

                if (ind1 != ind2 && ind1 >= 0 && ind2 >= 0 && ind1 < elements.Count() && ind2 < elements.Count())
                {

                    if (elements[ind1] == elements[ind2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[ind1]}!");

                        if (ind1 > ind2)
                        {
                            elements.RemoveAt(ind1);
                            elements.RemoveAt(ind2);
                        }
                        else
                        {
                            elements.RemoveAt(ind2);
                            elements.RemoveAt(ind1);
                        }
                        if (elements.Count() == 0)
                        {
                            Console.WriteLine($"You have won in {moves} turns!");
                            return;
                        }


                    }
                    else if (elements[ind1] != elements[ind2])
                    {
                        Console.WriteLine("Try again!");
                    }



                }
                else
                {

                    elements.Insert(elements.Count() / 2, $"-{moves}a");
                    elements.Insert(elements.Count() / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                input = Console.ReadLine();
            }
          //  if (input == "end" && elements.Count() != 0)
           // {
                Console.WriteLine($"Sorry you lose :(\n" + string.Join(" ", elements));

           // }
        }

    }

}
