using BSalonWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonWebApp.Models
{
    public class TimeTable
    {
        public List<WorkDay> WorkDays { get; set; } =
            new List<WorkDay>();

        public List<WorkDay> GetWorkDaysList(BSalonDbContext _context)
        {
            var lastDBRecord =  _context.Records.ToList().Last();
            if (lastDBRecord.Time.Date < DateTime.Now.Date.AddDays(30))
            {
                for (int i = 1; i <= (DateTime.Now.Date.AddDays(30).Date - lastDBRecord.Time.Date).TotalDays; i++)
                {
                    var TempDay = new WorkDay(lastDBRecord.Time.Date.AddDays(i));
                    foreach (var item in TempDay.Records)
                        _context.Records.Add(item);
                    _context.SaveChanges();                
                }
            }
          
            for (int i = 0; i <= 30; i++)
            {
                var TempDay = DateTime.Now.Date.AddDays(i);
                var DayRecords = _context.Records.Where(x => x.Time.Date == TempDay).ToList();
                WorkDays.Add(new WorkDay(DayRecords, TempDay));
            }

            return WorkDays;
        }

    }
}
