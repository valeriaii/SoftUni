using System;
using System.Linq;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            double totalPrice = 0;
            double totalPriceWithTax = 0;
            double taxes = 0;
            while (input!= "regular" && input!="special")
            {
                double num = Convert.ToDouble(input.ToString().Replace(".",","));
                if (num > 0)
                {
                    totalPrice += num;
                    
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }
                input = Console.ReadLine();
            }
            taxes = totalPrice * 0.2;
            totalPriceWithTax = totalPrice + taxes;
              if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            if(input== "special")
            {
                totalPriceWithTax = totalPriceWithTax - totalPriceWithTax * 0.1;
            }
            Console.WriteLine($"Congratulations you've just bought a new computer!\nPrice without taxes: {totalPrice:f2}$\nTaxes: {taxes:f2}$\n-----------\nTotal price: {totalPriceWithTax:f2}$");
            


        }
    }
}
