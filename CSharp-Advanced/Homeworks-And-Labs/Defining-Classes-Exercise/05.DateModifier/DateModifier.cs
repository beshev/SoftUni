using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int Difference { get; set; }

        public int GetDayBetweenTwoDates(string firstDate, string secondDates)
        {
            int[] first = firstDate.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] second = secondDates.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            DateTime startDate = new DateTime(first[0], first[1], first[2]);
            DateTime endDate = new DateTime(second[0], second[1], second[2]);
            return Math.Abs((int)((endDate - startDate).TotalDays));
        }
    }
}
