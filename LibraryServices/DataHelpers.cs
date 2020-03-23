using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryServices
{
    public class DataHelpers
    {
        public static IEnumerable<string> HumanizeBusinessHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach(var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);

                var TimeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(TimeEntry);
            }
            return hours;
        }

        public static string HumanizeDay(int number)
        {
            return Enum.GetName(typeof(DayOfWeek), number - 1);
        }

        public static string HumanizeTime(int time)
        {
            var result = TimeSpan.FromHours(time);
            return result.ToString("hh':'mm");
        }

    }
}
