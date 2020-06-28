using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BSalonWebApp.Pages
{
    public class RecordModel : PageModel
    {
        private readonly BSalonDbContext _context;

        [Required, StringLength(13)]
        public string Name { get; set; }
        [Required, StringLength(11)]
        public string Phone { get; set; }

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
    }
}