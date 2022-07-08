using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z\s]+)<<(?<price>\d+.?\d+)!(?<quantity>\d+)");
            string input = Console.ReadLine();
            var list = new List<string>();//list of items
            double totalPrice = 0;
            
            while (input != "Purchase")
            {
                Match matches= regex.Match(input);

                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    double price = double.Parse(matches.Groups["price"].Value);
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    list.Add(name);
                    totalPrice += price * quantity;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");

        }
    }
}
