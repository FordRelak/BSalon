using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace BSalonWebApp.Pages
{
    public class RecordModel : PageModel
    {
        private readonly BSalonDbContext _context;


        public Service Service { get; set; }

        public TimeTable TimeTable { get; set; }

        public RecordModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title)
        {
            if (title is null)
            {
                return Redirect(Url.Page("OnlineRecords"));
            }

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);

            TimeTable = new TimeTable();
            TimeTable.WorkDays = TimeTable.GetWorkDaysList(_context);
            
            
            
            
            
            
            return Page();
        }
    }
}