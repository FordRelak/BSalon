using BSalonWebApp.Models.SalonServices;
using BSalonWebApp.Models.Workers;
using System;

namespace BSalonWebApp.Models
{
    public class Record
    {
        public string Name { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public DateTime Time { get; set; }

        public string PhoneNumber { get; set; }

        public Service ServiceTitle { get; set; }

        public Worker Worker { get; set; }

        public bool IsFree { get; set; } = true;
    }
}
