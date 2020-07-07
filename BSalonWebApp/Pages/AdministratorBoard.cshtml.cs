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
        public AdministratorBoardModel(BSalonDbContext context) =>
            _context = context;

        public Record Record { get; set; }

        public List<Record> Records { get; set; }

        public IActionResult OnGet()
        {
            Records = _context.Records.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record != null)
            {
                _context.Records.Remove(record);
                await _context.SaveChangesAsync();
                return RedirectToPage("/AdministratorBoard");
            }

            return NotFound();
        }
    }
}