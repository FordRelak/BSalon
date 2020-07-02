using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSalonWebApp.Pages
{
    public class DailyScheduleModel : PageModel
    {
        private int _year, _month, _day;

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        private readonly BSalonDbContext _context;
        public DailyScheduleModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title, string year, string month, string day)
        {
            if (title == null || year == null || month == null || day == null)
                RedirectToPage("OnlineRecords");

            if (int.TryParse(year, out _year) && int.TryParse(month, out _month) && int.TryParse(day, out _day))
            {
                if (_year > 0 && _month > 0 && _day > 0)
                {
                    Year = _year;
                    Month = _month;
                    Day = _day;
                }
                else
                    RedirectToPage("OnlineRecords");
            }
            else
                RedirectToPage("OnlineRecords");

            return Page();
        }
    }
}