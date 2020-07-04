using BSalonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonWebApp.ExtensionMethods
{
    public static class DateTimeExtension 
    {
        public static void GetRecorsForMonth(this List<WorkDay> workDays, DateTime curDate, List<Record> records)
        {
            var toDate = curDate.AddDays(30);
            while (curDate < toDate)
            {
                workDays.Add(new WorkDay(records, curDate));
                curDate = curDate.AddDays(1);
            }
        }

        public static DateTime GetBeginningOfMonth(this DateTime day)
        {
            var curMonth = day.Month;
            if (day.Year > day.AddMonths(-1).Year)
            {
                return day;
            }
            else
            {
                //var prevMonth = curMonth - 1;
                while (curMonth == day.Month)
                {
                    day = day.AddDays(-1);
                }
                day = day.AddDays(1);
                return day;
            }
        }
    }
}
