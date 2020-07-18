using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public async Task<IActionResult> OnPostLogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }
    }
}