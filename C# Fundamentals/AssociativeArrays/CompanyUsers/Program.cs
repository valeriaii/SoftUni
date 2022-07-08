using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input = Console.ReadLine( );

            while (input!="End")
            {
                string[] information = input.Split(" -> ");
                string company = information[0];
                string employee = information[1];

                if (companies.ContainsKey(company))
                {
                    if (!companies[company].Contains(employee))
                    {
                        companies[company].Add(employee);
                    }
                }
                else
                {
                    companies[company] = new List<string>();
                    companies[company].Add(employee);
                }
                input = Console.ReadLine();
            }

            foreach (var company in companies.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
