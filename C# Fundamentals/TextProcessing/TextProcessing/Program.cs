using System;

namespace TextProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] userNames = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < userNames.Length; i++)
            
            {
                if (userNames[i].Length > 3 && userNames[i].Length < 16)
                {
                    bool valid = true;
                    foreach (var symbol in userNames[i])
                    {
                        if (!char.IsLetterOrDigit(symbol)&&symbol!='-'&&symbol!='_')
                        {
                            valid = false;
                        }
                    }
                    if (valid)
                    {
                        Console.WriteLine(userNames[i]);
                    }
                }

            }
        }
    }
}
