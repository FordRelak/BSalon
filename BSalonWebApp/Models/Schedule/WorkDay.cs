using System;
using System.Collections.Generic;
using System.Linq;

namespace BSalonWebApp.Models
{
    public class WorkDay
    {
        public List<Record> Records { get; set; }

        public DateTime DateTime { get; set; }

        public WorkDay(List<Record> records, DateTime dataTime)
        {

            DateTime = dataTime;

            List<Record> records1 = records.Where(record => record.Time.Date == DateTime.Date).OrderBy(r => r.Time.Hour).ToList();
            var length = records1.Count();
            for (int i = 0; i < 8 - length; i++)
            {
                if (records1.Any(r=>r.Time.Hour==i+9))
                    continue;
                records1.Add(new Record()
                {
                    Time = new DateTime(DateTime.Year,
                                        DateTime.Month,
                                        DateTime.Day,
                                        i + 9, 0, 0)
                });
            }
            Records = records1.OrderBy(r=>r.Time.Hour).ToList();

            #region comment
            //int j = 0;
            //for (int i = 0; i < 8; i++)
            //{
            //    if (records.Count() > j)
            //    {
            //        if (records[j].Time.Hour == i + 9)
            //            records1.Add(records[j++]);
            //        else
            //            records1.Add(new Record() { Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, i + 9, 0, 0) });
            //    }
            //    else
            //        records1.Add(new Record() { Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, i + 9, 0, 0) });
            //}
            #endregion

        }

        #region comment

        //public WorkDay(DateTime DateTime)
        //{
        //    this.DateTime = DateTime;

        //    Records = new List<Record>();
        //    Records.AddRange(new List<Record>() {
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 9,0,0)
        //         //   Worker = new Workers.Worker() { Name = "Sasha"}
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 10, 0, 0)
        //          //  Worker = new Workers.Worker() { Name = "Sasha" }
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 11, 0, 0)
        //           // Worker = new Workers.Worker() { Name = "Sasha" }
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 12, 0, 0)
        //           // Worker = new Workers.Worker() { Name = "Sasha" }
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 13, 0, 0)
        //            //Worker = new Workers.Worker() { Name = "Sasha" }
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 14, 0, 0)
        //           // Worker = new Workers.Worker() { Name = "Sasha" }
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 15, 0, 0)
        //            //Worker = new Workers.Worker() { Name = "Sasha" }
        //        },
        //        new Record()
        //        {
        //            Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 16, 0, 0)
        //            //Worker = new Workers.Worker() { Name = "Sasha" }
        //        }});
        //}
        #endregion
    }
}
