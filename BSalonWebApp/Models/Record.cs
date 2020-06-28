using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSalonWebApp.Models
{
    [Table("Records")]
    public class Record
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public DateTime Time { get; set; }

        public string PhoneNumber { get; set; }

        public int ServiceID { get; set; }

        public int WorkerID { get; set; }

        public bool IsFree { get; set; } = true;
    }
}
