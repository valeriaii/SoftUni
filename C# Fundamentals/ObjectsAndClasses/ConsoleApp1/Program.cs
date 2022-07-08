using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] phrase = new string[6] { "Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can’t live without this product." };
            String[] events = new string[6] { "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!" };
            String[] author = new string[8] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            String[] city = new string[5] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int numOfMessages = int.Parse(Console.ReadLine());
            Random random = new Random();

            for (int i = 0; i < numOfMessages; i++)
            {
                
                Console.WriteLine($"{phrase[random.Next(phrase.Length)]} {events[random.Next(events.Length)]} {author[random.Next(author.Length)]} – {city[random.Next(city.Length)]}.");
            }

        }
    }
}
