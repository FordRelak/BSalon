using BSalonWebApp.Data;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSalonWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BSalonDbContext _context;

        public IList<Service> Services { get; set; }

        public IndexModel(BSalonDbContext context) =>
            _context = context;

        public async Task OnGetAsync()
        {
            Services = await _context.Services.ToListAsync();

            switch (DateTime.Now.Month)
            {
                case 12:
                case 1:
                case 2:
                    ViewData["Season"] = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    ViewData["Season"] = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    ViewData["Season"] = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    ViewData["Season"] = "Autumm";
                    break;
                default:
                    break;
            }

            ViewData["AmountImgs"] = (int)(new System.IO.DirectoryInfo(System.IO.Path.Combine(Environment.CurrentDirectory, "wwwroot", "imgs", (string)ViewData["Season"])).GetFiles().Length);
        }
    }
}
