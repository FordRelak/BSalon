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
            var toDate = curDate.AddMonths(1);
            while (curDate < toDate)
            {
                workDays.Add(new WorkDay(records, curDate));
                curDate = curDate.AddDays(1);
            }       
        }        
    }
}
