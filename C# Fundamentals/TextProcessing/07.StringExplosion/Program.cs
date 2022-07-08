using System;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {

                if (strength>0 && input[i]!='>')
                {
                    input = input.Remove(i, 1);// Remove char on this index
                    strength--;//one bomb is used
                    i--; // after remove next char is moved 1 position, so return counter i to this char, decreasing i by 1  
                }
                else if(input[i]=='>')
                {
                    strength += int.Parse(input[i+1].ToString());
                    // takes the digit after '>' - bomb strength and add to bomb
                }


            }
            Console.WriteLine(input);
        }
    }
}
