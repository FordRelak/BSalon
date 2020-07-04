using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BSalonWebApp.Models
{
    [Table("Records")]
    public class Record
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Необходимое поле")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Необходимое поле")]
        public string SecondName { get; set; }

        [Display(Name = "Отчество")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Необходимое поле")]
        public string MiddleName { get; set; }

        [Display(Name = "Время")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Необходимое поле")]
        public DateTime Time { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Необходимое поле")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$",
                           ErrorMessage = "Неверный номер телефона")]
        public string PhoneNumber { get; set; }

        public int ServiceID { get; set; }

        public int WorkerID { get; set; }

        public bool IsFree { get; set; } = true;
    }
}
