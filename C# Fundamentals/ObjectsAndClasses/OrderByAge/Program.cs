using System;
using System.Collections.Generic;

namespace OrderByAge
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] splitted = input.Split();
                string name = splitted[0];
                string id = splitted[1];
                int age = int.Parse(splitted[2]);

                Person person = new Person();
                person.Name = name;
                person.ID = id;
                person.Age = age;

                people.Add(person);
                input = Console.ReadLine();
            }
            for (int i = 0; i < people.Count; i++)
            {
                int minIndex = i;
                for (int j = i; j < people.Count; j++)
                {
                    if (people[j].Age < people[minIndex].Age)
                    {
                        minIndex = j;
                    }

                }
                Person temp = people[minIndex];
                people[minIndex] = people[i];
                people[i] = temp;
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }
    }
}
