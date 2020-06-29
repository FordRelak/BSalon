using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonWebApp.Pages
{
    public class RecordModel : PageModel
    {
        private readonly BSalonDbContext _context;

        //[Display(Name = "Имя")]
        //[Required, StringLength(13)]
        //public string Name { get; set; }

        //[Display(Name ="Номер телефона")]
        //[Required, StringLength(11)]
        //public string Phone { get; set; }

        //[Display(Name ="Время")]
        //[DataType(DataType.Time)]
        //[Required]
        //public DateTime SelectedTime { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required]
        public Record Record { get; set; }

        [BindProperty(SupportsGet = true)]
        public Service Service { get; set; }

        //public IEnumerable<Record> Records { get; private set; }

       
        public WorkDay WorkDay { get; set; }

        public RecordModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title)
        {
            if (title is null)
            {
                return Redirect(Url.Page("OnlineRecords"));
            }

            //Records = _context.Records.AsEnumerable().Where(day => day);

            WorkDay = new WorkDay(_context.Records.ToList(), DateTime.Now.Date);

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);

            return Page();
        }

        //public void OnPostSelectedTime()
        //{
        //    Record.Time = 
        //}

        public async Task<IActionResult> OnPostAddRecordAsync(string title)
        {
            if (!ModelState.IsValid)
            {
                if (title is null)
                {
                    return Redirect(Url.Page("OnlineRecords"));
                }

                //Records = _context.Records.AsEnumerable().Where(day => day);

                WorkDay = new WorkDay(_context.Records.ToList(), DateTime.Now.Date);

                Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);

                return Page();
            }

            _context.Records.Add(Record);
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}