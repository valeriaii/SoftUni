using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsAndClasses
{
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Hi");
            Console.WriteLine($"My Name is {Name}");
        }
    }
}
