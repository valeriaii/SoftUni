using System;
using System.Collections.Generic;
using System.Text;

namespace DataModifier
{
    public class DataModifier
    {
        public static int CalculateDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            int result = (int)Math.Abs((first - second).TotalDays);

            return result;


        }
    }
}
