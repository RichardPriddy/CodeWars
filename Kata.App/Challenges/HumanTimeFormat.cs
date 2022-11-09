using System;
using System.Collections.Generic;

namespace CodeWars.App.Challenges
{
    public class HumanTimeFormat
    {
        public static string formatDuration(int seconds)
        {
            if (seconds == 0) return "now";

            TimeSpan ts = TimeSpan.FromSeconds(seconds);

            static string s(int number)
            {
                return number == 1 ? "" : "s";
            }

            var times = new List<string>();
            if (ts.Days > 0)
            {
                if (ts.Days <= 365)
                {
                    times.Add($"{ts.Days} day{s(ts.Days)}");
                }
                else
                {
                    var days = ts.Days % 365;
                    var years = (ts.Days - days) / 365;
                    times.Add($"{years} year{s(years)}");
                    times.Add($"{days} day{s(days)}");
                }
            }
            if (ts.Hours > 0)
            {
                times.Add($"{ts.Hours} hour{s(ts.Hours)}");
            }
            if (ts.Minutes > 0)
            {
                times.Add($"{ts.Minutes} minute{s(ts.Minutes)}");
            }
            if (ts.Seconds > 0)
            {
                times.Add($"{ts.Seconds} second{s(ts.Seconds)}");
            }

            var friendlyDate = string.Join(", ", times);
            var index = friendlyDate.LastIndexOf(",");
            if (index != -1)
            {
                friendlyDate = friendlyDate.Remove(index, 1).Insert(index, " and");
            }
            return friendlyDate;
        }
    }
}
