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

        public static DateTime GetNextValidDate(DateTime currentDay)
        {
            var nextValidDoW = ValidDays.First();

            foreach (var dayOfWeek in ValidDays)
            {
                if (currentDay.DayOfWeek < dayOfWeek)
                {
                    nextValidDoW = dayOfWeek;
                    break;
                }
            }

            var daysToAdd = (nextValidDoW - currentDay.DayOfWeek + 7) % 7;
            return currentDay.AddDays(daysToAdd).Date;
        }

        public static DateTime GetNextValidDate()
        {
            return GetNextValidDate(DateTime.Now);
        }

        public static DateTime GetNextWorkingDay(DateTime currentDay)
        {
            return currentDay;
        }
    }
}