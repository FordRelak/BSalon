using BSalonWebApp.Data;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSalonWebApp.Pages
{
    public class OnlineRecordsModel : PageModel
    {
        private readonly BSalonDbContext _context;

        [BindProperty]
        public IList<Service> Services { get; set; }

        public OnlineRecordsModel(BSalonDbContext context) =>
            _context = context;

        public async Task OnGetAsync() =>
            Services = await _context.Services.ToListAsync();

    }
}