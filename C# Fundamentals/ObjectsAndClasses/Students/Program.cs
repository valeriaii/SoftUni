using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public Student(string firstName, string lastName, float grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;


        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < numOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string firstName = input[0];
                string lastName = input[1];
                float grade = float.Parse(input[2], CultureInfo.InvariantCulture);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);


            }
            students = students.OrderBy(x => x.Grade).ToList();
            students.Reverse();
            Console.WriteLine(string.Join(Environment.NewLine,students));
        }
    }
}
