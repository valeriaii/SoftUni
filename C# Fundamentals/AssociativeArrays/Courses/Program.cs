using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input!="end")
            {
                string[] info = input.Split(" : ");
                string course = info[0];
                string student = info[1];

                
                if (courses.ContainsKey(course))
                {
                    courses[course].Add(student);
                }
                else
                {
                    courses[course] = new List<string>();
                    courses[course].Add(student);

                }
                input = Console.ReadLine();
            }
            foreach (var course in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value.OrderBy(x=>x))
                {
                        Console.WriteLine($"-- {student}");
                }
                
            }
         }
    }
}
