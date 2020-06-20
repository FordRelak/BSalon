using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonWebApp.Models
{
    public class WorkDay
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        public List<Record> Records { get; set; }

        public DateTime DateTime { get; set; }

        public WorkDay(DateTime DateTime)
        {
            this.DateTime = DateTime;

            Records = new List<Record>();
            Records.AddRange(new List<Record>() { 
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 9,0,0),
                    Worker = new Workers.Worker() { Name = "Sasha"}
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 10, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 11, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 12, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 13, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 14, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 15, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                },
                new Record()
                {
                    Time = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 16, 0, 0),
                    Worker = new Workers.Worker() { Name = "Sasha" }
                }});
        }
    }
}
