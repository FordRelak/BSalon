using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSalonWebApp.Models.SalonServices
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }
    }
}
