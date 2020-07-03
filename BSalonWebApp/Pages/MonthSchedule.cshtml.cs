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
            WorkDay.GetRecorsForMonth(DateTime.Now, 
                _context.Records.Where(x => x.Time.Date.Month >= DateTime.Now.Month &&
                                            x.Time.Date.Month <  DateTime.Now.AddMonths(1).Month).ToList());

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);
        }

        private void LoadNewMonth(int monthOffset)
        {
            WorkDay.GetRecorsForMonth(DateTime.Now,
                _context.Records.Where(x => x.Time.Date.Month >= WorkDay[0].DateTime.Month &&
                                            x.Time.Date.Month < WorkDay[0].DateTime.AddMonths(monthOffset).Month).ToList());
          
            Service = _context.Services.First(serviceTitle => serviceTitle.Title == ViewData["TitleForPartialView"].ToString());
        }

    }
}