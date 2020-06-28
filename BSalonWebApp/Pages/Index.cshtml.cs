using BSalonWebApp.Data;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task OnGetAsync() =>
            Services = await _context.Services.ToListAsync();
    }
}
