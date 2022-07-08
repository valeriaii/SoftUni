using System;
using System.IO;
using System.Text;

namespace StreamsFilesDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                

                using (StreamReader reader = new StreamReader(@"D:\SoftUni\C# Advanced\Exercise\StreamsFilesDirectories\cooltex.txt"))
                {
                    int index = 0;
                    string textFromFile = reader.ReadLine();
                    while (textFromFile != null)
                    {
                        if (index % 2 != 0)
                        {
                            writer.WriteLine(textFromFile);

                        }
                        index++;
                        textFromFile = reader.ReadLine();

                    }


                }
            }
            string text = "pesho";
            using (FileStream stream = new FileStream("text.txt", FileMode.OpenOrCreate))
            {
                Console.WriteLine(stream.Length);
                stream.Seek(stream.Length, SeekOrigin.Begin);
                byte[] data = Encoding.UTF8.GetBytes(text);
                Console.WriteLine($"{string.Join(",",data)}");
                stream.Write(data, 0, data.Length);

            }





        }
    }
}
