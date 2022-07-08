using System;
using System.Collections.Generic;
using System.Globalization;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string, decimal[]> products = new Dictionary<string, decimal[]>();
            string input = Console.ReadLine();

            while (input!="buy")
            {
                string[] splitted = input.Split();
                string product = splitted[0];
                decimal price = decimal.Parse(splitted[1]);
                decimal quantity = decimal.Parse(splitted[2]);
                if (!products.ContainsKey(product))
                {
                    products[product]= new decimal[2];
                    products[product][0] = price;
                    products[product][1] = quantity;
                }
                else
                {
                    products[product][0] = price;
                    products[product][1]+=quantity;
                }
                input = Console.ReadLine();
            }
            foreach (var product in products)
            {
                decimal totalPrice = products[product.Key][0] * products[product.Key][1];
                Console.WriteLine(product.Key+ " -> " +totalPrice);
            }
        }
    }
}
