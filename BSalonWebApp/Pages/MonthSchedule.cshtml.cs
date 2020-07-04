using BSalonWebApp.Data;
using BSalonWebApp.ExtensionMethods;
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
    public class MonthScheduleModel : PageModel
    {
        private readonly BSalonDbContext _context;

        [BindProperty(SupportsGet = true)]
        public Service Service { get; set; }

        public List<WorkDay> WorkDay { get; set; } = new List<WorkDay>();

        public DateTime CurDay { get; set; }

        public MonthScheduleModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title)
        {
            if (title is null)
            {
                return Redirect(Url.Page("OnlineRecords"));
            }

            ViewData["TitleForPartialView"] = title;

            LoadProperties(title);
            return Page();
        }

        private void LoadProperties(string title)
        {
            var curDate = DateTime.Now;
            var toDate = DateTime.Now.AddDays(30);
            var tempRecords = _context.Records.ToList();
            while (curDate < toDate)
            {
                WorkDay.Add(new WorkDay(tempRecords, curDate));
                curDate = curDate.AddDays(1);
            }

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);
        }

    }
}