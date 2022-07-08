using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            int numOfRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfRows; i++)
            {
                string student = Console.ReadLine();
                decimal grade = decimal.Parse(Console.ReadLine());

                if (students.ContainsKey(student))
                {
                    students[student].Add(grade);

                }
                else
                {
                    students[student] = new List<decimal>();
                    students[student].Add(grade);
                }
            }

            students.Where(x=>x.Value.Average()>=4.5m);
            students.OrderByDescending(x=> x.Value.Average());

            foreach (var student in students.Where(x => x.Value.Average() >= 4.5m).OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
                
            }
        }
    }
}
