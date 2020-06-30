using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BSalonWebApp.Pages
{
    public class AdministratorBoardModel : PageModel
    {
        private readonly BSalonDbContext _context;

        [BindProperty]
        public IList<Service> Services { get; set; }

        [BindProperty]
        public IList<Record> Records { get; set; }

        public List<WorkDay> WorkDays { get; set; } = new List<WorkDay>();

        public AdministratorBoardModel(BSalonDbContext context) =>
            _context = context;

        public async Task OnGetAsync()
        { 
            Services = await _context.Services.ToListAsync();
            //Records = await _context.Records.ToListAsync();
            //var temp = _context.Records.First(x => x.Time.Date == DateTime.Now.Date);

            var DateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var DateNow1 = new DateTime(DateNow.Year, DateNow.Month + 1, 1);
            int counter = 0;
            while (DateNow.AddDays(counter).Month < DateNow1.Month)
            {
                WorkDays.Add(new WorkDay(_context.Records.ToList(), DateNow.AddDays(counter++) ));
            }

            //WorkDays.Add(new WorkDay(_context.Records.ToList(), DateTime.Now.Date));
        }
    }
}