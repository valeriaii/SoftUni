using System;
using System.IO;
using System.Text;

public class EvenLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";

        Console.WriteLine(ProcessLines(inputFilePath));
    }

    public static string ProcessLines(string inputFilePath)
    {
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            int index = 0;
            string textFromFile = reader.ReadLine();
            StringBuilder result = new StringBuilder();
            while (textFromFile != null)
            {
                if (index % 2 == 0)
                {
                    string[] line = textFromFile.Split();
                    for (int i = 0; i < line.Length; i++)
                    {
                        string currEl = line[i];
                        for (int j = 0; j < line[i].Length; j++)
                        {
                            if (currEl[j] == '-' || 
                                currEl[j] == ',' ||
                                currEl[j] == '.'|| 
                                currEl[j] == '!'|| 
                                currEl[j] == '?' )
                            {
                            currEl[j] = '@';
                            }
                        }
                    }
                   Console.WriteLine(line);

                }
                index++;
                textFromFile = reader.ReadLine();

            }
        }
    }
}
