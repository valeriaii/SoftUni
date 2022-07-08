using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
           

            string input = Console.ReadLine();

            double totalIncome = 0;

            while (input!="end of shift")
            {
                Regex regex = new Regex(@"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+[.]?[\d]+)\$");
                bool isValid = regex.IsMatch(input);
                if (isValid)
                {


                   
                    string name = regex.Match(input).Groups["customer"].Value;
                    string product = regex.Match(input).Groups["product"].Value;
                    double price = double.Parse(regex.Match(input).Groups["price"].Value);
                    int quantity = int.Parse(regex.Match(input).Groups["count"].Value);

                    double currIncome = price * quantity;
                    totalIncome += currIncome;

                    Console.WriteLine($"{name}: {product} - {currIncome:f2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
