using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSalonWebApp.Pages
{
    public class RecordModel : PageModel
    {
        private readonly BSalonDbContext _context;

        public Service Service { get; set; }

        public List<WorkDay> WorkDays { get; set; } =
           new List<WorkDay>();


        public RecordModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title)
        {
            if (title is null)
            {
                return Redirect(Url.Page("OnlineRecords"));
            }

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);

            for (int i = 0; i <= 30; i++)
            {
                var TempDay = DateTime.Now.Date.AddDays(i);
                var DayRecords = _context.Records.Where(x => x.Time.Date == TempDay).ToList();
                WorkDays.Add(new WorkDay(DayRecords, TempDay));
            }

            return Page();
        }
    }
}