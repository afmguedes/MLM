using System;
using System.Collections.Generic;
using System.Linq;

namespace MLM.UnitTests
{
    public static class Helper
    {
        private static readonly List<DayOfWeek> ValidDays =
            new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Wednesday,
                DayOfWeek.Friday
            };

        public static DateTime GetNextAvailableDate(DateTime today)
        {
            var nextValidDoW = ValidDays.First();

            foreach (var dayOfWeek in ValidDays)
            {
                if (today.DayOfWeek < dayOfWeek)
                {
                    nextValidDoW = dayOfWeek;
                    break;
                }
            }

            var daysToAdd = (nextValidDoW - today.DayOfWeek + 7) % 7;
            return today.AddDays(daysToAdd).Date;
        }

        public static DateTime GetNextAvailableDate()
        {
            return GetNextAvailableDate(DateTime.Now);
        }
    }
}