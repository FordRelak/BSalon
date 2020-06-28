using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSalonWebApp.Models.Workers
{
    [Table("Workers")]
    public class Worker
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }
    }
}
