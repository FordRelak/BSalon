using BSalonAPI.Models.SalonServices;
using BSalonAPI.Models.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonAPI.Models
{
    public class Record
    {
        public string Name { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public string Time { get; set; }

        public string PhoneNumber { get; set; }

        public Service ServiceTitle { get; set; }

        public Worker Worker { get; set; }
    }
}
