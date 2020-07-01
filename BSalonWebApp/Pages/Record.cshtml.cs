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

        [BindProperty(SupportsGet = true)]
        [Required]
        public Record Record { get; set; }

        [BindProperty(SupportsGet = true)]
        public Service Service { get; set; }


        public List<WorkDay> WorkDay { get; set; } = new List<WorkDay>();

        public RecordModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title)
        {
            if (title is null)
            {
                return Redirect(Url.Page("OnlineRecords"));
            }            

            LoadProperties(title);

            return Page();
        }

        public async Task<IActionResult> OnPostAddRecordAsync(string title)
        {
            if (!ModelState.IsValid)
            {
                if (title is null)
                {
                    return Redirect(Url.Page("OnlineRecords"));
                }

                //Records = _context.Records.AsEnumerable().Where(day => day);

                LoadProperties(title);

                return Page();
            }

            Record.ServiceID = Service.Id;
            _context.Records.Add(Record);
            await _context.SaveChangesAsync();

            return Page();
        }

        private void LoadProperties(string title)
        {
            var curDate = DateTime.Now;
            var toDate = DateTime.Now.AddDays(30);
            while (curDate < toDate)
            {
                WorkDay.Add(new WorkDay(_context.Records.ToList(), curDate));
                curDate = curDate.AddDays(1);
            }

            Service = _context.Services.First(serviceTitle => serviceTitle.Title == title);
        }
    }
}