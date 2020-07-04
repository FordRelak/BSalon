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

        public List<WorkDay> WorkDay { get; set; } 

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

            // LoadProperties(title);
            CurDay = DateTime.Now.AddMonths(3);
            LoadNewMonth(3);
            return Page();
        }

        private void LoadProperties(string title)
        {
            WorkDay.GetRecorsForMonth(DateTime.Now, 
                _context.Records.Where(x => x.Time.Date.Month >= DateTime.Now.Date.Month &&
                                            x.Time.Date.Month <  DateTime.Now.AddMonths(1).Date.Month).ToList());

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);
        }

        private void LoadNewMonth(int monthOffset)
        {
            WorkDay = new List<WorkDay>();
            WorkDay.GetRecorsForMonth(CurDay.GetBeginningOfMonth(),
                _context.Records.Where(x => x.Time.Date.Month >= CurDay.Date.AddMonths(monthOffset).Month &&
                                            x.Time.Date.Month < CurDay.Date.AddMonths(monthOffset + 1).Month).ToList());
          
            Service = _context.Services.First(serviceTitle => serviceTitle.Title == ViewData["TitleForPartialView"].ToString());
        }

    }
}