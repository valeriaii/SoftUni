using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regexName = new Regex(@"(?<name>[A-Za-z]+)");//pattern for finding a name
            Regex regexNumbers = new Regex(@"(?<digits>\d+)");//pattern for finding the digits

            int sumOfDigits = 0;

            Dictionary<string, int> participants = new Dictionary<string, int>();

           List<string> names = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input!="end of race")
            {
                MatchCollection matchedNames = regexName.Matches(input);//join letters
                MatchCollection matchedDigits = regexNumbers.Matches(input);//join digits
                string currName = string.Join("", matchedNames);
                string currDigit = string.Join("", matchedDigits);

                sumOfDigits = 0;
                for (int i = 0; i < currDigit.Length; i++)
                {
                    //convert curr digit to int
                    sumOfDigits += int.Parse(currDigit[i].ToString());
                }
                //check if curr participant is on the list
                if (names.Contains(currName))
                {
                    //check if in the dict
                    if (participants.ContainsKey(currName))
                    {
                        //we add sumofdigits to his sum
                        participants[currName] += sumOfDigits;
                    }
                    else
                    {
                        //we add currName and sumofdigits
                        participants[currName] = sumOfDigits;
                    }
                }
                input = Console.ReadLine();
            }
            //find winner
            var winners = participants.OrderByDescending(x=>x.Value).Take(3);

            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x=>x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");
            }

            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");
            }

            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");
            }
        }
    }
}
